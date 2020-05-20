using System.Threading.Tasks;
using Blog.Core.Domain.Models;
using MongoDB.Driver;

namespace Blog.Data.DbContext
{
    public interface IDocumentsDbContext
    {
        IClientSessionHandle Session { get; }

        IMongoDatabase Database { get; }

        public IMongoCollection<Author> Authors { get; }
        public IMongoCollection<Post> Posts { get; }
        public IMongoCollection<Comment> Comments { get; }

        public Task Configure();
    }
}