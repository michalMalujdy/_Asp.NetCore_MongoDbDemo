using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.App.Features.Posts.Commands.CreatePost;
using Blog.App.Features.Posts.Commands.UpdatePost;
using Blog.App.Features.Posts.Queries.GetPost;
using Blog.App.Resources;
using Blog.Core.Repositories.Posts;
using Blog.Core.Resources;
using Blog.Data.DbModels;
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
        public Task<PostWithAuthorResource> GetPost(
            [FromRoute] GetPostQuery query)
            => _postsRepository.GetPostWithAuthor(query.PostId);

        [HttpGet]
        public Task<List<PostWithAuthorResource>> GetPosts()
            => _postsRepository.GetAll();

        [HttpPut("{postId}")]
        public async Task UpdatePost(
            [FromRoute] Guid postId,
            [FromBody] UpdatePostCommand command)
        {
            command.PostId = postId;
            await _mediator.Send(command);
        }

        [HttpDelete("{postId}")]
        public Task Delete([FromRoute] Guid postId)
            => _postsRepository.Delete(postId);
    }
}