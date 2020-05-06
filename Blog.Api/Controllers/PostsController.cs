using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.App.Features.Posts.Commands.CreatePost;
using Blog.App.Features.Posts.Commands.DeletePost;
using Blog.App.Features.Posts.Commands.UpdatePost;
using Blog.App.Features.Posts.Queries.GetPost;
using Blog.App.Features.Posts.Queries.GetPosts;
using Blog.App.Resources;
using Blog.Core.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/posts")]
    public class PostsController : MediatorController
    {
        [HttpPost]
        public Task<IdResource> CreatePost(
            [FromBody] CreatePostCommand command)
            => Mediator.Send(command);

        [HttpGet("{postId}")]
        public Task<PostCompleteResource> GetPost(
            [FromRoute] GetPostQuery query)
            => Mediator.Send(query);

        [HttpGet]
        public Task<List<PostCompleteResource>> GetPosts()
            => Mediator.Send(new GetPostsQuery());

        [HttpPut("{postId}")]
        public async Task UpdatePost(
            [FromRoute] Guid postId,
            [FromBody] UpdatePostCommand command)
        {
            command.PostId = postId;
            await Mediator.Send(command);
        }

        [HttpDelete("{postId}")]
        public Task Delete(
            [FromRoute] DeletePostCommand command)
            => Mediator.Send(command);
    }
}