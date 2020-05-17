using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Api.Configurations;
using Blog.Core.Data.Repositories;
using Blog.Core.Domain.Models;
using Blog.Data.Repositories.MongoRepository;
using MongoDB.Driver;

namespace Blog.Data.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly IMongoRepository _mongoRepository;

        public CommentsRepository(IMongoRepository mongoRepository)
            => _mongoRepository = mongoRepository;

        public async Task<Guid> Create(Comment comment, CancellationToken ct)
        {
            await _mongoRepository
                .CommentsCollection
                .InsertOneAsync(comment, ct);

            return comment.Id;
        }
    }
}