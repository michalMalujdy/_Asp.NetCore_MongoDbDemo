using System;
using System.Threading.Tasks;
using Blog.Api.Configurations;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories.Authors;
using MongoDB.Driver;

namespace Blog.Data.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly IMongoCollection<Author> _authorsCollection;

        public AuthorsRepository(MongoDbSettings dbSettings)
        {
            var db = new MongoClient(dbSettings.ConnectionString)
                .GetDatabase(dbSettings.DbName);

            _authorsCollection = db.GetCollection<Author>("Authors");
        }

        public async Task<Guid> Create(Author author)
        {
            await _authorsCollection.InsertOneAsync(author);

            return author.Id;
        }
    }
}