using AutoMapper;
using Blog.Core.Domain.Models;

namespace Blog.App.Features.Posts.Commands.CreatePost
{
    public class CreatePostMaps : Profile
    {
        public CreatePostMaps()
        {
            CreateMap<CreatePostCommand, Post>()
                .AfterMap((src, dest) =>
                {
                    dest.SetTitle(src.Title);
                });
        }
    }
}