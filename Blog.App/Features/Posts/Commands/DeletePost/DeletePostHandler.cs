using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Repositories;
using MediatR;

namespace Blog.App.Features.Posts.Commands.DeletePost
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostsRepository _postsRepository;

        public DeletePostHandler(IPostsRepository postsRepository)
            => _postsRepository = postsRepository;

        public async Task<Unit> Handle(DeletePostCommand command, CancellationToken ct)
        {
            await _postsRepository.Delete(command.PostId, ct);

            return Unit.Value;
        }
    }
}