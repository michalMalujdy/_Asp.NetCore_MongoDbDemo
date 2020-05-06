using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Api.Configurations;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories;
using Blog.Core.Resources;
using MongoDB.Driver;

namespace Blog.Data.Repositories.Posts
{
    public class PostsRepository : IPostsRepository
    {
        private readonly IMongoCollection<Post> _postsCollection;
        private readonly IMongoCollection<Author> _authorsCollection;
        private readonly IMongoCollection<Comment> _commentsCollection;

        private readonly IMapper _mapper;

        public PostsRepository(MongoDbSettings dbSettings, IMapper mapper)
        {
            var db = new MongoClient(dbSettings.ConnectionString)
                .GetDatabase(dbSettings.DbName);

            _postsCollection = db.GetCollection<Post>("Posts");
            _authorsCollection = db.GetCollection<Author>("Authors");
            _commentsCollection = db.GetCollection<Comment>("Comments");

            _mapper = mapper;
        }

        public async Task<Guid> Create(Post post, CancellationToken ct)
        {
            await _postsCollection.InsertOneAsync(post, ct);

            return post.Id;
        }

        public async Task<Post> Get(Guid postId, CancellationToken ct)
        {
            var postsCursor = await _postsCollection.FindAsync(
                post => post.Id == postId,
                cancellationToken: ct);

            return await postsCursor.FirstAsync(ct);
        }

        public async Task<PostCompleteResource> GetPost(Guid postId, CancellationToken ct)
        {
            var postWithAuthorDbModel = await _postsCollection
                .IncludeAll(_authorsCollection, _commentsCollection)
                .FirstOrDefaultAsync(ct);

            if (postWithAuthorDbModel == null)
                return null;

            return _mapper.Map<PostCompleteResource>(postWithAuthorDbModel);
        }

        public async Task<List<PostCompleteResource>> GetAll(CancellationToken ct)
        {
            var posts = await _postsCollection
                .IncludeAll(_authorsCollection, _commentsCollection)
                .ToListAsync(ct);

            return _mapper.Map<List<PostCompleteResource>>(posts);
        }

        public Task Update(Post post, CancellationToken ct)
            => _postsCollection.ReplaceOneAsync(
                p => p.Id == post.Id,
                post,
                cancellationToken: ct);

        public Task Delete(Guid postId, CancellationToken ct)
            => _postsCollection.DeleteOneAsync(p => p.Id == postId, ct);
    }
}