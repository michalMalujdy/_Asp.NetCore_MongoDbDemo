using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Repositories;
using MediatR;

namespace Blog.App.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IPostsRepository _postsRepository;

        public UpdatePostHandler(IPostsRepository postsRepository)
            => _postsRepository = postsRepository;

        public async Task<Unit> Handle(UpdatePostCommand command, CancellationToken ct)
        {
            var post = await _postsRepository.Get(command.PostId);

            if (post == null)
                return Unit.Value;

            post.Title = command.Title;
            post.Content = command.Content;
            post.AuthorId = command.AuthorId;
            post.UpdatedAt = DateTimeOffset.Now;

            await _postsRepository.Update(post);

            return Unit.Value;
        }
    }
}