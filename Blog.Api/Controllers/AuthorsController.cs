using System;
using System.Threading.Tasks;
using Blog.App.Features.Authors.Commands.CreateAuthor;
using Blog.App.Features.Authors.Commands.DeleteAuthor;
using Blog.App.Features.Authors.Commands.UpdateAuthor;
using Blog.App.Features.Authors.Queries.GetAuthor;
using Blog.App.Features.Authors.Queries.GetAuthors;
using Blog.App.Features.Common.Author;
using Blog.App.Resources;
using Blog.Core.Resources;
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

        [HttpPut("{authorId}")]
        public async Task UpdateAuthor(
            [FromRoute] Guid authorId,
            [FromBody] UpdateAuthorCommand command)
        {
            command.AuthorId = authorId;

            await Mediator.Send(command);
        }

        [HttpDelete("{authorId}")]
        public Task DeleteAuthor(
            [FromRoute] DeleteAuthorCommand command)
            => Mediator.Send(command);
    }
}