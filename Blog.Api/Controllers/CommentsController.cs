using System.Threading.Tasks;
using Blog.App.Features.Comments.Commands.CreateComment;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/comments")]
    public class CommentsController : MediatorController
    {
        [HttpPost]
        public Task CreateComment(
            [FromBody] CreateCommentCommand command)
            => Mediator.Send(command);
    }
}