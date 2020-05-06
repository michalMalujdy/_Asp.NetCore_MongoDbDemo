using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Api.Configurations;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories;
using MongoDB.Driver;

namespace Blog.Data.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly IMongoCollection<Comment> _commentsCollection;

        public CommentsRepository(MongoDbSettings dbSettings)
        {
            var db = new MongoClient(dbSettings.ConnectionString)
                .GetDatabase(dbSettings.DbName);

            _commentsCollection = db.GetCollection<Comment>("Comments");
        }

        public async Task<Guid> Create(Comment comment, CancellationToken ct)
        {
            await _commentsCollection.InsertOneAsync(comment, ct);

            return comment.Id;
        }
    }
}