using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories.PostsRepository.Models;

namespace Blog.Core.Repositories.PostsRepository
{
    public interface IPostsRepository
    {
        Task<Guid> Create(Post post);

        Task<Post> Get(Guid postId);
        Task<PostWithAuthorModel> GetPostWithAuthor(Guid postId);

        Task<ICollection<Post>> GetAll();

        Task Update(Post post);

        Task Delete(Guid postId);
    }
}