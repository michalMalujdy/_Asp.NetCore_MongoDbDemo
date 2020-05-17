using AutoMapper;
using Blog.Core.Domain.Models;

namespace Blog.App.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostMaps : Profile
    {
        public UpdatePostMaps()
        {
            CreateMap<UpdatePostCommand, Post>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.SetTitle(src.Title);
                });
        }
    }
}