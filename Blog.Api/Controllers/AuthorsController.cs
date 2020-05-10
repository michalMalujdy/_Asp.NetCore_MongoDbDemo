using System.Threading.Tasks;
using Blog.App.Features.Authors.Commands.CreateAuthor;
using Blog.App.Features.Authors.Queries.GetAuthor;
using Blog.App.Features.Authors.Queries.GetAuthors;
using Blog.App.Features.Common.Author;
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
        public Task<PagableListResult<AuthorCommonResult>> GetAuthors(
            [FromQuery] GetAuthorsQuery query)
            => Mediator.Send(query);

        [HttpGet("{authorId}")]
        public Task<AuthorCommonResult> GetAuthor(
            [FromRoute] GetAuthorQuery query)
            => Mediator.Send(query);
    }
}