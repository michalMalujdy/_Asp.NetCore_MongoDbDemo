using System;
using MediatR;

namespace Blog.App.Features.Authors.Queries.GetAuthor
{
    public class GetAuthorQuery : IRequest<GetAuthorResult>
    {
        public Guid AuthorId { get; set; }
    }
}