using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Data.Repositories;
using Blog.Core.Domain.Models;
using Blog.Core.Resources;
using Blog.Data.DbContext;
using Blog.Data.DbModels;
using MongoDB.Driver;

namespace Blog.Data.Repositories.Posts
{
    public class PostsRepository : IPostsRepository
    {
        private readonly IDocumentsDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostsRepository(IDocumentsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Create(Post post, CancellationToken ct)
        {
            await _dbContext
                .Posts
                .InsertOneAsync(
                    _dbContext.Session,
                    post,
                    cancellationToken: ct);

            return post.Id;
        }

        public async Task<Post> Get(Guid postId, CancellationToken ct)
        {
            var postsCursor = await _dbContext
                .Posts
                .FindAsync(
                    _dbContext.Session,
                    post => post.Id == postId,
                    cancellationToken: ct);

            return await postsCursor.FirstAsync(ct);
        }

        public async Task<PostCompleteResource> GetPost(Guid postId, CancellationToken ct)
        {
            var postWithAuthorDbModel = await _dbContext
                .Posts
                .IncludeAll(_dbContext.Authors, _dbContext.Comments, _dbContext.Session)
                .Match(p => p.Id == postId)
                .FirstOrDefaultAsync(ct);

            if (postWithAuthorDbModel == null)
                return null;

            return _mapper.Map<PostCompleteResource>(postWithAuthorDbModel);
        }

        public async Task<PagableListResult<PostCompleteResource>> GetMany(
            int pageNr,
            int pageSize,
            string? filter,
            CancellationToken ct)
        {
            var baseQuery = _dbContext
                .Posts
                .IncludeAll(_dbContext.Authors, _dbContext.Comments, _dbContext.Session);

            baseQuery = ApplyFilter(baseQuery, filter);

            var posts = await baseQuery
                .Skip(pageNr * pageSize)
                .Limit(pageSize)
                .ToListAsync(ct);

            return new PagableListResult<PostCompleteResource>
            {
                Results = _mapper.Map<List<PostCompleteResource>>(posts),
                TotalCount = (await baseQuery.Count().FirstOrDefaultAsync(ct))?.Count ?? 0
            };
        }

        public Task Update(Post post, CancellationToken ct)
            => _dbContext
                .Posts
                .ReplaceOneAsync(
                    _dbContext.Session,
                    p => p.Id == post.Id,
                    post,
                    cancellationToken: ct);

        public Task Delete(Guid postId, CancellationToken ct)
            => _dbContext
                .Posts
                .DeleteOneAsync(
                    _dbContext.Session,
                    p => p.Id == postId,
                    cancellationToken: ct);

        private IAggregateFluent<PostCompleteDbModel> ApplyFilter(
            IAggregateFluent<PostCompleteDbModel> baseQuery,
            string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return baseQuery;

            filter = filter
                .ToUpperInvariant()
                .Trim();

            return baseQuery.Match(post => post.Title
                .ToUpperInvariant()
                .Contains(filter));
        }
    }
}