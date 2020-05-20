using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Data.Repositories;
using Blog.Core.Domain.Models;
using Blog.Core.Resources;
using Blog.Data.DbContext;
using MongoDB.Driver;

namespace Blog.Data.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly IDocumentsDbContext _dbContext;

        public AuthorsRepository(IDocumentsDbContext mongoRepository)
            => _dbContext = mongoRepository;

        public async Task<Guid> Create(Author author, CancellationToken ct)
        {
            await _dbContext
                .Authors
                .InsertOneAsync(
                    _dbContext.Session,
                    author,
                    cancellationToken: ct);

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
                return _dbContext
                    .Authors
                    .Find(
                        _dbContext.Session,
                        _ =>true);

            filter = filter
                .Trim()
                .ToUpperInvariant();

            return _dbContext
                .Authors
                .Find(
                    _dbContext.Session,
                    author => author.FullNameUpperCased.Contains(filter));
        }

        public async Task<Author> Get(Guid authorId, CancellationToken ct)
        {
            var cursor = await _dbContext
                .Authors
                .FindAsync(
                    _dbContext.Session,
                    author => author.Id == authorId,
                    cancellationToken: ct);

            return await cursor.FirstOrDefaultAsync(ct);
        }

        public Task Delete(Guid authorId, CancellationToken ct)
            => _dbContext.Authors.DeleteOneAsync(
                _dbContext.Session,
                a => a.Id == authorId,
                cancellationToken: ct);
    }
}