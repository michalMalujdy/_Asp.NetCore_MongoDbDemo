using System.Linq;
using AutoMapper;
using Blog.Core.Resources;
using Blog.Data.DbModels;

namespace Blog.Data.MapperProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostWithAuthorsDbModel, PostWithAuthorResource>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(
                    src => src.Authors.FirstOrDefault()));
        }
    }
}