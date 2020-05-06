using System;
using System.Threading.Tasks;
using Blog.Core.Domain.Models;
using Blog.Core.Resources;

namespace Blog.Core.Repositories.Authors
{
    public interface IAuthorsRepository
    {
        Task<Guid> Create(Author author);
        Task<PagableListResult<Author>> GetMany(int pageNr, int pageSize);
    }
}