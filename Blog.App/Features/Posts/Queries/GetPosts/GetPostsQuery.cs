using System.Collections.Generic;
using Blog.Core.Resources;
using MediatR;

namespace Blog.App.Features.Posts.Queries.GetPosts
{
    public class GetPostsQuery : IRequest<List<PostCompleteResource>>
    {
    }
}