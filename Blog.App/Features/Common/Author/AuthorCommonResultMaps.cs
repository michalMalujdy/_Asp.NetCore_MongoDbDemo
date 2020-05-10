using AutoMapper;

namespace Blog.App.Features.Common.Author
{
    public class AuthorCommonResultMaps : Profile
    {
        public AuthorCommonResultMaps()
        {
            CreateMap<Core.Domain.Models.Author, AuthorCommonResult>();
        }
    }
}