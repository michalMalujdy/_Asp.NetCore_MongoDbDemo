using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Repositories;
using MediatR;

namespace Blog.App.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IMapper _mapper;

        public UpdatePostHandler(IPostsRepository postsRepository, IMapper mapper)
        {
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePostCommand command, CancellationToken ct)
        {
            var post = await _postsRepository.Get(command.PostId, ct);

            if (post == null)
                return Unit.Value;

            _mapper.Map(command, post);
            post.UpdatedAt = DateTimeOffset.Now;

            await _postsRepository.Update(post, ct);

            return Unit.Value;
        }
    }
}