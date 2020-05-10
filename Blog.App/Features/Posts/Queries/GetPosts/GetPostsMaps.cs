using AutoMapper;
using Blog.Core.Domain.Models;

namespace Blog.App.Features.Posts.Queries.GetPosts
{
    public class GetPostsMaps : Profile
    {
        public GetPostsMaps()
        {
            CreateMap<Post, GetPostsResult>();
        }
    }
}