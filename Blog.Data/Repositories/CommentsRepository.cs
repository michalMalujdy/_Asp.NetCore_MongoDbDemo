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

        public async Task<Comment> Get(Guid commentId, CancellationToken ct)
        {
            var commentsCursor = await _dbContext
                .Comments
                .FindAsync(
                    _dbContext.Session,
                    c => c.Id == commentId,
                    cancellationToken: ct);

            return await commentsCursor.FirstAsync(ct);
        }

        public Task Update(Comment comment, CancellationToken ct)
            => _dbContext
                .Comments
                .ReplaceOneAsync(
                    _dbContext.Session,
                    c => c.Id == comment.Id,
                    comment,
                    cancellationToken: ct);

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