using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.Domain.Models;
using Blog.Core.Resources;

namespace Blog.Core.Repositories.Posts
{
    public interface IPostsRepository
    {
        Task<Guid> Create(Post post);

        Task<Post> Get(Guid postId);
        Task<PostWithAuthorResource> GetPostWithAuthor(Guid postId);

        Task<List<PostWithAuthorResource>> GetAll();

        Task Update(Post post);

        Task Delete(Guid postId);
    }
}