using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Repositories;
using Blog.Core.Resources;
using MediatR;

namespace Blog.App.Features.Posts.Queries.GetPost
{
    public class GetPostHandler : IRequestHandler<GetPostQuery, PostCompleteResource>
    {
        private readonly IPostsRepository _postsRepository;

        public GetPostHandler(IPostsRepository postsRepository)
            => _postsRepository = postsRepository;

        public Task<PostCompleteResource> Handle(GetPostQuery query, CancellationToken ct)
            => _postsRepository.GetPost(query.PostId, ct);
    }
}