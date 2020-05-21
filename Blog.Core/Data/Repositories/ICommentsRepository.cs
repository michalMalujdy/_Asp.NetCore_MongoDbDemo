using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Domain.Models;

namespace Blog.Core.Data.Repositories
{
    public interface ICommentsRepository
    {
        Task<Guid> Create(Comment comment, CancellationToken ct);

        Task Delete(Guid commentId, CancellationToken ct);
    }
}