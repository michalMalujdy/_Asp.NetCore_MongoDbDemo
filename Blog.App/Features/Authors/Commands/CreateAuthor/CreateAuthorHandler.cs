using System.Threading;
using System.Threading.Tasks;
using Blog.App.Resources;
using Blog.Core.Data.Repositories;
using Blog.Core.Domain.Models;
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
            var author = new Author();
            author.SetNames(command.FirstName, command.LastName);
            author.SetInitialTimestamps();

            var id = await _authorsRepository.Create(author, ct);

            return new IdResource(id);
        }
    }
}