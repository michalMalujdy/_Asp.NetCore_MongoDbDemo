using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Api.Configurations;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories;
using Blog.Core.Resources;
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

        public async Task<Guid> Create(Author author, CancellationToken ct)
        {
            await _authorsCollection.InsertOneAsync(author, ct);

            return author.Id;
        }

        public async Task<PagableListResult<Author>> GetMany(
            int pageNr,
            int pageSize,
            string? filter,
            CancellationToken ct)
        {
            var list = new PagableListResult<Author>();

            var baseQuery = GetBaseQuery(filter);

            list.Results = await baseQuery
                .Skip(pageSize * pageNr)
                .Limit(pageSize)
                .ToListAsync(ct);

            list.TotalCount = await baseQuery
                .CountDocumentsAsync(ct);

            return list;
        }

        private IFindFluent<Author, Author> GetBaseQuery(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return _authorsCollection.Find(_ => true);

            filter = filter
                .Trim()
                .ToUpperInvariant();

            return _authorsCollection
                .Find(author => author.FullNameUpperCased.Contains(filter));
        }

        public async Task<Author> Get(Guid authorId, CancellationToken ct)
        {
            var cursor = await _authorsCollection
                .FindAsync(author => author.Id == authorId, cancellationToken: ct);

            return await cursor.FirstOrDefaultAsync(ct);
        }
    }
}