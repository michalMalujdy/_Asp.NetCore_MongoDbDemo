using Blog.Core.Domain.Models;
using Blog.Core.Resources;
using MediatR;

namespace Blog.App.Features.Authors.Commands.GetAuthors
{
    public class GetAuthorsQuery : IRequest<PagableListResult<Author>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }
}