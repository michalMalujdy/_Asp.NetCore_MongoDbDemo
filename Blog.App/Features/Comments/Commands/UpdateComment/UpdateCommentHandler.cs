using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Data.Repositories;
using MediatR;

namespace Blog.App.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly ICommentsRepository _commentsRepository;

        public UpdateCommentHandler(ICommentsRepository commentsRepository)
            => _commentsRepository = commentsRepository;

        public async Task<Unit> Handle(UpdateCommentCommand command, CancellationToken ct)
        {
            var comment = await _commentsRepository.Get(command.CommentId, ct);

            comment.Nickname = command.Nickname;
            comment.Content = command.Content;

            comment.UpdatedAt = DateTimeOffset.Now;

            await _commentsRepository.Update(comment, ct);

            return Unit.Value;
        }
    }
}