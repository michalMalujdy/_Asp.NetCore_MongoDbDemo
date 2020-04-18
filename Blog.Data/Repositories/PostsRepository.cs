using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Api.Configurations;
using Blog.Core.Domain.Models;
using Blog.Core.Domain.Services;
using MongoDB.Driver;

namespace Blog.Data.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly IMongoCollection<Post> _postsCollection;

        public PostsRepository(MongoDbSettings dbSettings)
        {
            _postsCollection = new MongoClient(dbSettings.ConnectionString)
                .GetDatabase(dbSettings.DbName)
                .GetCollection<Post>("Posts");
        }

        public async Task<Guid> Create(Post post)
        {
            await _postsCollection.InsertOneAsync(post);

            return post.Id;
        }

        public async Task<Post> Get(Guid postId)
        {
            var postsCursor = await _postsCollection.FindAsync(post => post.Id == postId);

            return await postsCursor.FirstAsync();
        }

        public async Task<ICollection<Post>> GetAll()
        {
            var postsCursor = await _postsCollection.FindAsync(post => true);

            return await postsCursor.ToListAsync();
        }

        public Task Update(Post post)
            => _postsCollection.ReplaceOneAsync(
                p => p.Id == post.Id,
                post);

        public Task Delete(Guid postId)
            => _postsCollection.DeleteOneAsync(p => p.Id == postId);
    }
}