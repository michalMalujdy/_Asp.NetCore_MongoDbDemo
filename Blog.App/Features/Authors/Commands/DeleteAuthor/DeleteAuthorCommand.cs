using System;
using MediatR;

namespace Blog.App.Features.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest
    {
        public Guid AuthorId { get; set; }
    }
}