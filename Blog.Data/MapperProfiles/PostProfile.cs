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
            CreateMap<PostCompleteDbModel, PostCompleteResource>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(
                    src => src.Authors.FirstOrDefault()));
        }
    }
}