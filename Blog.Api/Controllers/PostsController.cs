using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Api.Resources;
using Blog.Core.Domain.Models;
using Blog.Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsRepository _postsRepository;

        public PostsController(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        [HttpPost]
        public async Task<Guid> CreatePost([FromBody] CreatePostCommand command)
        {
            var postEntity = new Post(command.Title, command.Content);

            var postId = await _postsRepository.Create(postEntity);

            return postId;
        }

        [HttpGet]
        public Task<ICollection<Post>> GetPosts()
            => _postsRepository.GetAll();
    }
}