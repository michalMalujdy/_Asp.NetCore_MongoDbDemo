using System.Threading.Tasks;
using Blog.App.Features.Comments.Commands.CreateComment;
using Blog.App.Features.Comments.Commands.DeleteComment;
using Blog.App.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/comments")]
    public class CommentsController : MediatorController
    {
        [HttpPost]
        public Task<IdResource> CreateComment(
            [FromBody] CreateCommentCommand command)
            => Mediator.Send(command);

        [HttpDelete("{commentId}")]
        public Task DeleteComment(
            [FromRoute] DeleteCommentCommand command)
            => Mediator.Send(command);
    }
}