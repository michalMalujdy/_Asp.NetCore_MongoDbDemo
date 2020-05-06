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
    public class AuthorsController : MediatorController
    {
        [HttpPost]
        public Task<IdResource> CreateAuthor(
            [FromBody] CreateAuthorCommand command)
            => Mediator.Send(command);

        [HttpGet]
        public Task<PagableListResult<Author>> GetAuthors(
            [FromQuery] GetAuthorsQuery query)
            => Mediator.Send(query);

        [HttpGet("{authorId}")]
        public Task<Author> GetAuthor(
            [FromRoute] GetAuthorQuery query)
            => Mediator.Send(query);
    }
}