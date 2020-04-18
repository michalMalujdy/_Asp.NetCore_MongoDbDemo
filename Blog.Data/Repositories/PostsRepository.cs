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
        private readonly IMongoCollection<Post> _posts;

        public PostsRepository(MongoDbSettings dbSettings)
        {
            _posts = new MongoClient(dbSettings.ConnectionString)
                .GetDatabase(dbSettings.DbName)
                .GetCollection<Post>("Posts");
        }

        public async Task<Guid> Create(Post post)
        {
            await _posts.InsertOneAsync(post);

            return post.Id;
        }

        public async Task<ICollection<Post>> GetAll()
        {
            var posts = await _posts.FindAsync(post => true);

            return await posts.ToListAsync();
        }
    }
}