using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Data.Repositories;
using Blog.Core.Domain.Models;
using MediatR;

namespace Blog.App.Features.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorsRepository _authorsRepository;

        public UpdateAuthorHandler(IAuthorsRepository authorsRepository)
            => _authorsRepository = authorsRepository;

        public async Task<Unit> Handle(UpdateAuthorCommand command, CancellationToken ct)
        {
            var author = new Author
            {
                Id = command.AuthorId,
                UpdatedAt = DateTimeOffset.Now
            };

            author.SetNames(command.FirstName, command.LastName);

            await _authorsRepository.Update(author, ct);

            return Unit.Value;
        }
    }
}