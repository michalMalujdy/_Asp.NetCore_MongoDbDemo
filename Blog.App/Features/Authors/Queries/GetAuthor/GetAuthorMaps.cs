using AutoMapper;
using Blog.Core.Domain.Models;

namespace Blog.App.Features.Authors.Queries.GetAuthor
{
    public class GetAuthorMaps : Profile
    {
        public GetAuthorMaps()
        {
            CreateMap<Author, GetAuthorResult>();
        }
    }
}