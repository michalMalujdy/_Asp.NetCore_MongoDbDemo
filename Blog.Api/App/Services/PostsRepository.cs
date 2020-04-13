using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Api.Configurations;
using Blog.Api.Domain.Models;
using Blog.Api.Domain.Services;
using MongoDB.Driver;

namespace Blog.Api.App.Services
{
    public class PostsRepository : IPostsRepository
    {
        private readonly IMongoCollection<Post> _posts;

        public PostsRepository(MongoDbConfiguration dbConfig)
        {
            _posts = new MongoClient(dbConfig.ConnectionString)
                .GetDatabase(dbConfig.DbName)
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