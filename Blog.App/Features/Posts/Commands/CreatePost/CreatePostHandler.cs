using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.App.Resources;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories;
using MediatR;

namespace Blog.App.Features.Posts.Commands.CreatePost
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, IdResource>
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IMapper _mapper;

        public CreatePostHandler(IPostsRepository postsRepository, IMapper mapper)
        {
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        public async Task<IdResource> Handle(CreatePostCommand command, CancellationToken ct)
        {
            var post = _mapper.Map<Post>(command);
            post.SetInitialTimestamps();

            var postId = await _postsRepository.Create(post);

            return new IdResource(postId);
        }
    }
}