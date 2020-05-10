using System;
using Blog.App.Features.Common.Author;
using MediatR;

namespace Blog.App.Features.Authors.Queries.GetAuthor
{
    public class GetAuthorQuery : IRequest<AuthorCommonResult>
    {
        public Guid AuthorId { get; set; }
    }
}