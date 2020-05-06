using System;
using System.Threading.Tasks;
using Blog.Core.Domain.Models;

namespace Blog.Core.Repositories.Authors
{
    public interface IAuthorsRepository
    {
        Task<Guid> Create(Author author);
    }
}