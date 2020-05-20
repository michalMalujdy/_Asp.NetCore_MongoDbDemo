using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Data.Repositories;
using MediatR;

namespace Blog.App.Features.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IAuthorsRepository _authorsRepository;

        public DeleteAuthorHandler(IAuthorsRepository authorsRepository)
            => _authorsRepository = authorsRepository;

        public async Task<Unit> Handle(DeleteAuthorCommand command, CancellationToken ct)
        {
            await _authorsRepository.Delete(command.AuthorId, ct);

            return Unit.Value;
        }
    }
}