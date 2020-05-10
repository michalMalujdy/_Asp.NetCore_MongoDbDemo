using AutoMapper;
using Blog.Core.Resources;

namespace Blog.App.Features.Posts.Queries.GetPosts
{
    public class GetPostsMaps : Profile
    {
        public GetPostsMaps()
        {
            CreateMap<PostCompleteResource, GetPostsResult>();
        }
    }
}