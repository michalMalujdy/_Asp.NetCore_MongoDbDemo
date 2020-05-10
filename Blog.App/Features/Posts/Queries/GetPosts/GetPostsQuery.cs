using Blog.Core.Resources;
using MediatR;

namespace Blog.App.Features.Posts.Queries.GetPosts
{
    public class GetPostsQuery : IRequest<PagableListResult<GetPostsResult>>, IPageable, IFilterable
    {
        public int PageNr { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; }
    }
}