using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blog.Core.Repositories;
using Blog.Core.Resources;
using MediatR;

namespace Blog.App.Features.Posts.Queries.GetPosts
{
    public class GetPostsHandler : IRequestHandler<GetPostsQuery, List<PostCompleteResource>>
    {
        private readonly IPostsRepository _postsRepository;

        public GetPostsHandler(IPostsRepository postsRepository)
            => _postsRepository = postsRepository;

        public Task<List<PostCompleteResource>> Handle(GetPostsQuery query, CancellationToken ct)
            => _postsRepository.GetAll(ct);
    }
}