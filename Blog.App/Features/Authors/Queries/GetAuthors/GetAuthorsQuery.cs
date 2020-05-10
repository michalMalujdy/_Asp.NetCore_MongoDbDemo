using Blog.Core.Resources;
using MediatR;

namespace Blog.App.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsQuery : IRequest<PagableListResult<GetAuthorsResult>>, IPageable, IFilterable
    {
        public int PageNr { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; }
    }
}