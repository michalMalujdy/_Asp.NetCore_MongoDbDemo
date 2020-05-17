using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Data.Repositories;
using Blog.Core.Domain.Models;
using Blog.Core.Resources;
using Blog.Data.DbModels;
using Blog.Data.Repositories.MongoRepository;
using MongoDB.Driver;

namespace Blog.Data.Repositories.Posts
{
    public class PostsRepository : IPostsRepository
    {
        private readonly IMongoRepository _mongoRepository;
        private readonly IMapper _mapper;

        public PostsRepository(IMongoRepository mongoRepository, IMapper mapper)
        {
            _mongoRepository = mongoRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(Post post, CancellationToken ct)
        {
            await _mongoRepository
                .PostsCollection
                .InsertOneAsync(post, ct);

            return post.Id;
        }

        public async Task<Post> Get(Guid postId, CancellationToken ct)
        {
            var postsCursor = await _mongoRepository
                .PostsCollection
                .FindAsync(post => post.Id == postId, cancellationToken: ct);

            return await postsCursor.FirstAsync(ct);
        }

        public async Task<PostCompleteResource> GetPost(Guid postId, CancellationToken ct)
        {
            var postWithAuthorDbModel = await _mongoRepository
                .PostsCollection
                .IncludeAll(_mongoRepository.AuthorsCollection, _mongoRepository.CommentsCollection)
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
            var baseQuery = _mongoRepository
                .PostsCollection
                .IncludeAll(_mongoRepository.AuthorsCollection, _mongoRepository.CommentsCollection);

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
            => _mongoRepository
                .PostsCollection
                .ReplaceOneAsync(
                    p => p.Id == post.Id,
                    post,
                    cancellationToken: ct);

        public Task Delete(Guid postId, CancellationToken ct)
            => _mongoRepository
                .PostsCollection
                .DeleteOneAsync(p => p.Id == postId, ct);

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