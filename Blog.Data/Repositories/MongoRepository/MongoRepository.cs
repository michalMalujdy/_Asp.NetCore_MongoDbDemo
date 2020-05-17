using Blog.Api.Configurations;
using Blog.Core.Domain.Models;
using MongoDB.Driver;

namespace Blog.Data.Repositories.MongoRepository
{
    public class MongoRepository : IMongoRepository
    {
        public IMongoDatabase Db { get; }

        public IMongoCollection<Author> AuthorsCollection { get; }
        public IMongoCollection<Post> PostsCollection { get; }
        public IMongoCollection<Comment> CommentsCollection { get; }

        public MongoRepository(MongoDbSettings dbSettings)
        {
            var db = new MongoClient(dbSettings.ConnectionString)
                .GetDatabase(dbSettings.DbName);

            PostsCollection = db.GetCollection<Post>("Posts");
            AuthorsCollection = db.GetCollection<Author>("Authors");
            CommentsCollection = db.GetCollection<Comment>("Comments");
        }
    }
}