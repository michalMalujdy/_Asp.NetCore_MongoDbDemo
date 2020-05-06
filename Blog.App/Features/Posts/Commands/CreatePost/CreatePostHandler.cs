using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.App.Resources;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories;
using MediatR;

namespace Blog.App.Features.Posts.Commands.CreatePost
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, IdResource>
    {
        private readonly IPostsRepository _postsRepository;

        public CreatePostHandler(IPostsRepository postsRepository)
            => _postsRepository = postsRepository;

        public async Task<IdResource> Handle(CreatePostCommand command, CancellationToken ct)
        {
            var postEntity = new Post
            {
                Title = command.Title,
                Content = command.Content,
                AuthorId = command.AuthorId
            };

            postEntity.SetInitialTimestamps();

            var postId = await _postsRepository.Create(postEntity);

            return new IdResource(postId);
        }
    }
}