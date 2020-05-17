using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Data.Repositories;
using Blog.Core.Resources;
using MediatR;

namespace Blog.App.Features.Posts.Queries.GetPost
{
    public class GetPostHandler : IRequestHandler<GetPostQuery, GetPostResult>
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IMapper _mapper;

        public GetPostHandler(IPostsRepository postsRepository, IMapper mapper)
        {
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        public async Task<GetPostResult> Handle(GetPostQuery query, CancellationToken ct)
        {
            var post = await _postsRepository.GetPost(query.PostId, ct);

            return _mapper.Map<GetPostResult>(post);
        }
    }
}