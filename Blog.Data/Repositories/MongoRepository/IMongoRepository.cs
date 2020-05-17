using System.Threading.Tasks;
using Blog.Core.Domain.Models;
using MongoDB.Driver;

namespace Blog.Data.Repositories.MongoRepository
{
    public interface IMongoRepository
    {
        public IMongoDatabase Db { get; }

        public IMongoCollection<Author> AuthorsCollection { get; }
        public IMongoCollection<Post> PostsCollection { get; }
        public IMongoCollection<Comment> CommentsCollection { get; }

        public Task Configure();
    }
}