using AutoMapper;
using Blog.Core.Domain.Models;
using Blog.Core.Resources;

namespace Blog.App.Features.Posts.Queries.GetPost
{
    public class GetPostMaps : Profile
    {
        public GetPostMaps()
        {
            CreateMap<PostCompleteResource, GetPostResult>();
            CreateMap<Comment, GetPostResult.Comment>();
        }
    }
}