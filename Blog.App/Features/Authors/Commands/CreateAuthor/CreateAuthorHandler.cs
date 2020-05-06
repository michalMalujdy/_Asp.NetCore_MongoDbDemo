using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.App.Resources;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories.Authors;
using MediatR;

namespace Blog.App.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, IdResource>
    {
        private readonly IAuthorsRepository _authorsRepository;

        public CreateAuthorHandler(IAuthorsRepository authorsRepository)
            => _authorsRepository = authorsRepository;

        public async Task<IdResource> Handle(CreateAuthorCommand command, CancellationToken ct)
        {
            var now = DateTimeOffset.Now;

            var author = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = command.FirstName,
                LastName = command.LastName,
                CreatedAt = now,
                UpdatedAt = now
            };

            var id = await _authorsRepository.Create(author);

            return new IdResource(id);
        }
    }
}