using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.App.Features.Posts.Commands.CreatePost;
using Blog.App.Features.Posts.Commands.UpdatePost;
using Blog.App.Features.Posts.Queries.GetPost;
using Blog.App.Resources;
using Blog.Core.Repositories.Posts.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
            => _mediator = mediator;

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
        public Task UpdatePost(
            [FromRoute] Guid postId,
            [FromBody] UpdatePostCommand command)
            => _mediator.Send(command);

        [HttpDelete("{postId}")]
        public Task Delete([FromRoute] Guid postId)
            => _postsRepository.Delete(postId);
    }
}