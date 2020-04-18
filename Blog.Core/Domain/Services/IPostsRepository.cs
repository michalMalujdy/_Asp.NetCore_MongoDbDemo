using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.Domain.Models;

namespace Blog.Core.Domain.Services
{
    public interface IPostsRepository
    {
        Task<Guid> Create(Post post);
        Task<ICollection<Post>> GetAll();
    }
}