using System;
using Blog.Core.Domain.Models;
using MediatR;

namespace Blog.App.Features.Authors.GetAuthor
{
    public class GetAuthorQuery : IRequest<Author>
    {
        public Guid AuthorId { get; set; }
    }
}