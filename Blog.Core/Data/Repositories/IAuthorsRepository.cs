using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Domain.Models;
using Blog.Core.Resources;

namespace Blog.Core.Data.Repositories
{
    public interface IAuthorsRepository
    {
        Task<Guid> Create(Author author, CancellationToken ct);

        Task<PagableListResult<Author>> GetMany(int pageNr, int pageSize, string? filter, CancellationToken ct);

        Task<Author> Get(Guid authorId, CancellationToken ct);

        Task Delete(Guid authorId, CancellationToken ct);

        Task Update(Author author, CancellationToken ct);
    }
}