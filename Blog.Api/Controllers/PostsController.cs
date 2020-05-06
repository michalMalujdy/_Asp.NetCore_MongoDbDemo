using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Api.Resources.Posts;
using Blog.App.Features.Posts.Commands.CreatePost;
using Blog.App.Features.Posts.Queries.GetPost;
using Blog.App.Resources;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories.Posts;
using Blog.Core.Repositories.Posts.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPostsRepository _postsRepository;

        public PostsController(IMediator mediator, IPostsRepository postsRepository)
        {
            _mediator = mediator;
            _postsRepository = postsRepository;
        }

        [HttpPost]
        public Task<IdResource> CreatePost(
            [FromBody] CreatePostCommand command)
            => _mediator.Send(command);

        [HttpGet("{postId}")]
        public Task<PostWithAuthorModel> GetPost(
            [FromRoute] GetPostQuery query)
            => _postsRepository.GetPostWithAuthor(query.PostId);

        [HttpGet]
        public Task<List<PostWithAuthorModel>> GetPosts()
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