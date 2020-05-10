using AutoMapper;
using Blog.Core.Domain.Models;

namespace Blog.App.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsMaps : Profile
    {
        public GetAuthorsMaps()
        {
            CreateMap<Author, GetAuthorsResult>();
        }
    }
}