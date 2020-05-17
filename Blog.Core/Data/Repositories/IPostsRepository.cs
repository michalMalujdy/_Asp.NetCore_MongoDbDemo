using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Domain.Models;
using Blog.Core.Resources;

namespace Blog.Core.Data.Repositories
{
    public interface IPostsRepository
    {
        Task<Guid> Create(Post post, CancellationToken ct);

        Task<Post> Get(Guid postId, CancellationToken ct);
        Task<PostCompleteResource> GetPost(Guid postId, CancellationToken ct);

        Task<PagableListResult<PostCompleteResource>> GetMany(int pageNr, int pageSize, string filter, CancellationToken ct);

        Task Update(Post post, CancellationToken ct);

        Task Delete(Guid postId, CancellationToken ct);
    }
}