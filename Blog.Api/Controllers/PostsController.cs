using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Api.Resources;
using Blog.Api.Resources.Posts;
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
        public async Task<Guid> CreatePost(
            [FromBody] CreatePostCommand command)
        {
            var now = DateTimeOffset.Now;
            
            var postEntity = new Post
            {
                Title = command.Title,
                Content = command.Content,
                AuthorId = command.AuthorId,
                CreatedAt = now,
                UpdatedAt = now
            };

            var postId = await _postsRepository.Create(postEntity);

            return postId;
        }
        
        [HttpGet("{postId}")]
        public Task<Post> GetPost(
            [FromRoute] Guid postId)
            => _postsRepository.Get(postId);

        [HttpGet]
        public Task<ICollection<Post>> GetPosts()
            => _postsRepository.GetAll();

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(
            [FromRoute] Guid postId,
            [FromBody] UpdatePostCommand command)
        {
            var post = await _postsRepository.Get(postId);

            if (post == null)
                return new NotFoundResult();

            post.Title = command.Title;
            post.Content = command.Content;
            post.UpdatedAt = DateTimeOffset.Now;

            await _postsRepository.Update(post);

            return Ok();
        }

        [HttpDelete("{postId}")]
        public Task Delete([FromRoute] Guid postId)
            => _postsRepository.Delete(postId);
    }
}