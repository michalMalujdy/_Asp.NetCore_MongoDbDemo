using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Domain.Models;
using Blog.Core.Resources;

namespace Blog.Core.Repositories
{
    public interface IPostsRepository
    {
        Task<Guid> Create(Post post, CancellationToken ct);

        Task<Post> Get(Guid postId, CancellationToken ct);
        Task<PostCompleteResource> GetPost(Guid postId, CancellationToken ct);

        Task<List<PostCompleteResource>> GetAll(CancellationToken ct);

        Task Update(Post post, CancellationToken ct);

        Task Delete(Guid postId, CancellationToken ct);
    }
}