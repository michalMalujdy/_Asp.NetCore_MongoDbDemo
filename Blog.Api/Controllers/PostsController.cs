using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.App.Features.Posts.Commands.CreatePost;
using Blog.App.Features.Posts.Commands.UpdatePost;
using Blog.App.Features.Posts.Queries.GetPost;
using Blog.App.Resources;
using Blog.Core.Repositories;
using Blog.Core.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/posts")]
    public class PostsController : MediatorController
    {
        private readonly IPostsRepository _postsRepository;

        public PostsController(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        [HttpPost]
        public Task<IdResource> CreatePost(
            [FromBody] CreatePostCommand command)
            => Mediator.Send(command);

        [HttpGet("{postId}")]
        public Task<PostCompleteResource> GetPost(
            [FromRoute] GetPostQuery query)
            => _postsRepository.GetPost(query.PostId);

        [HttpGet]
        public Task<List<PostCompleteResource>> GetPosts()
            => _postsRepository.GetAll();

        [HttpPut("{postId}")]
        public async Task UpdatePost(
            [FromRoute] Guid postId,
            [FromBody] UpdatePostCommand command)
        {
            command.PostId = postId;
            await Mediator.Send(command);
        }

        [HttpDelete("{postId}")]
        public Task Delete([FromRoute] Guid postId)
            => _postsRepository.Delete(postId);
    }
}