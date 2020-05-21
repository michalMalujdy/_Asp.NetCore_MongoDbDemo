using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Data.Repositories;
using MediatR;

namespace Blog.App.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly ICommentsRepository _commentsRepository;

        public DeleteCommentHandler(ICommentsRepository commentsRepository)
            => _commentsRepository = commentsRepository;

        public async Task<Unit> Handle(DeleteCommentCommand command, CancellationToken ct)
        {
            await _commentsRepository.Delete(command.CommentId, ct);

            return Unit.Value;
        }
    }
}