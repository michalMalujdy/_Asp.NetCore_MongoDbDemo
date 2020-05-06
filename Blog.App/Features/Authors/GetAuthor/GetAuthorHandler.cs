using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories;
using MediatR;

namespace Blog.App.Features.Authors.GetAuthor
{
    public class GetAuthorHandler : IRequestHandler<GetAuthorQuery, Author>
    {
        private readonly IAuthorsRepository _authorsRepository;

        public GetAuthorHandler(IAuthorsRepository authorsRepository)
            => _authorsRepository = authorsRepository;

        public Task<Author> Handle(GetAuthorQuery query, CancellationToken ct)
            => _authorsRepository.Get(query.AuthorId, ct);
    }
}