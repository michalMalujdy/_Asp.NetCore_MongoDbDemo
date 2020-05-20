using System;
using System.Threading.Tasks;
using Blog.Api.Configurations;
using Blog.Core.Domain.Models;
using MongoDB.Driver;

namespace Blog.Data.DbContext
{
    public class DocumentsDbContext : IDocumentsDbContext, IDisposable
    {
        public IClientSessionHandle Session { get; }

        public IMongoDatabase Database { get; }

        public IMongoCollection<Author> Authors { get; }
        public IMongoCollection<Post> Posts { get; }
        public IMongoCollection<Comment> Comments { get; }

        public DocumentsDbContext(MongoDbSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            Session = client.StartSession(new ClientSessionOptions { CausalConsistency = true });
            Database = Session.Client.GetDatabase(dbSettings.DbName);

            Authors = Database.GetCollection<Author>("Authors");
            Posts = Database.GetCollection<Post>("Posts");
            Comments = Database.GetCollection<Comment>("Comments");
        }

        public async Task Configure()
        {
            await Authors.Indexes
                .CreateOneAsync(Builders<Author>.IndexKeys.Ascending(a => a.FullNameUpperCased));

            await Posts.Indexes
                .CreateOneAsync(Builders<Post>.IndexKeys.Ascending(p => p.TitleUpperCased));
        }

        public void Dispose()
            => Session.Dispose();
    }
}