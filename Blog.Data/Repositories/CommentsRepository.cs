using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Data.Repositories;
using Blog.Core.Domain.Models;
using Blog.Data.DbContext;

namespace Blog.Data.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly IDocumentsDbContext _dbContext;

        public CommentsRepository(IDocumentsDbContext mongoRepository)
            => _dbContext = mongoRepository;

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
    }
}