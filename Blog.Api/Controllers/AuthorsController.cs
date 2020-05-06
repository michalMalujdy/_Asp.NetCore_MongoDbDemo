using System.Threading.Tasks;
using Blog.App.Features.Authors.Commands.CreateAuthor;
using Blog.App.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<IdResource> CreateAuthor(
            [FromBody] CreateAuthorCommand command)
            => _mediator.Send(command);
    }
}