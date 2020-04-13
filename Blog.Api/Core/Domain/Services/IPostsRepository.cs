using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Api.Domain.Models;

namespace Blog.Api.Domain.Services
{
    public interface IPostsRepository
    {
        Task<Guid> Create(Post post);
        Task<ICollection<Post>> GetAll();
    }
}