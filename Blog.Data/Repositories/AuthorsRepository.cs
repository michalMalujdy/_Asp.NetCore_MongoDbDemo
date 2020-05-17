using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Api.Configurations;
using Blog.Core.Data.Repositories;
using Blog.Core.Domain.Models;
using Blog.Core.Resources;
using Blog.Data.Repositories.MongoRepository;
using MongoDB.Driver;

namespace Blog.Data.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly IMongoRepository _mongoRepository;

        public AuthorsRepository(IMongoRepository mongoRepository)
            => _mongoRepository = mongoRepository;

        public async Task<Guid> Create(Author author, CancellationToken ct)
        {
            await _mongoRepository
                .AuthorsCollection
                .InsertOneAsync(author, ct);

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
                return _mongoRepository
                    .AuthorsCollection
                    .Find(_ => true);

            filter = filter
                .Trim()
                .ToUpperInvariant();

            return _mongoRepository
                .AuthorsCollection
                .Find(author => author.FullNameUpperCased.Contains(filter));
        }

        public async Task<Author> Get(Guid authorId, CancellationToken ct)
        {
            var cursor = await _mongoRepository
                .AuthorsCollection
                .FindAsync(author => author.Id == authorId, cancellationToken: ct);

            return await cursor.FirstOrDefaultAsync(ct);
        }
    }
}