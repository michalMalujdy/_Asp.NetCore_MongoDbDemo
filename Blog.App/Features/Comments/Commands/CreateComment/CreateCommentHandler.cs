using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.App.Resources;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories;
using MediatR;

namespace Blog.App.Features.Comments.Commands.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, IdResource>
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMapper _mapper;

        public CreateCommentHandler(ICommentsRepository commentsRepository, IMapper mapper)
        {
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }

        public async Task<IdResource> Handle(CreateCommentCommand command, CancellationToken ct)
        {
            var comment = _mapper.Map<Comment>(command);
            comment.SetInitialTimestamps();

            var id = await _commentsRepository.Create(comment, ct);

            return new IdResource(id);
        }
    }
}