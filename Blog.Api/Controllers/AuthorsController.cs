using System.Threading.Tasks;
using Blog.App.Features.Authors.Commands.CreateAuthor;
using Blog.App.Features.Authors.Commands.GetAuthors;
using Blog.App.Features.Authors.GetAuthor;
using Blog.App.Resources;
using Blog.Core.Domain.Models;
using Blog.Core.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public Task<IdResource> CreateAuthor(
            [FromBody] CreateAuthorCommand command)
            => _mediator.Send(command);

        [HttpGet]
        public Task<PagableListResult<Author>> GetAuthors(
            [FromQuery] GetAuthorsQuery query)
            => _mediator.Send(query);

        [HttpGet("{authorId}")]
        public Task<Author> GetAuthor(
            [FromRoute] GetAuthorQuery query)
            => _mediator.Send(query);
    }
}