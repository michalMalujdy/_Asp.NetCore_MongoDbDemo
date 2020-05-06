using Blog.App.Resources;
using MediatR;

namespace Blog.App.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<IdResource>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}