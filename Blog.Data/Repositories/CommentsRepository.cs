using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Data.Repositories;
using Blog.Core.Domain.Models;
using Blog.Data.DbContext;
using MongoDB.Driver;

namespace Blog.Data.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly IDocumentsDbContext _dbContext;

        public CommentsRepository(IDocumentsDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<Guid> Create(Comment comment, CancellationToken ct)
        {
            await _dbContext
                .Comments
                .InsertOneAsync(
                    _dbContext.Session,
                    comment,
                    cancellationToken: ct);

            return comment.Id;
        }

        public Task Delete(Guid commentId, CancellationToken ct)
            => _dbContext
                .Comments
                .DeleteOneAsync(
                    _dbContext.Session,
                    c => c.Id == commentId,
                    cancellationToken: ct);
    }
}