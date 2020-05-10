using AutoMapper;
using Blog.Core.Domain.Models;

namespace Blog.App.Features.Posts.Queries.GetPost
{
    public class GetPostMaps : Profile
    {
        public GetPostMaps()
        {
            CreateMap<Post, GetPostResult>();
            CreateMap<Comment, GetPostResult.Comment>();
        }
    }
}