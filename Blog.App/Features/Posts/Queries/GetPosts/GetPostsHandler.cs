using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Repositories;
using Blog.Core.Resources;
using MediatR;

namespace Blog.App.Features.Posts.Queries.GetPosts
{
    public class GetPostsHandler : IRequestHandler<GetPostsQuery, PagableListResult<GetPostsResult>>
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IMapper _mapper;

        public GetPostsHandler(IPostsRepository postsRepository, IMapper mapper)
        {
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        public async Task<PagableListResult<GetPostsResult>> Handle(GetPostsQuery query, CancellationToken ct)
        {
            var posts = await _postsRepository.GetMany(
                query.PageNr,
                query.PageSize,
                query.Filter,
                ct);

            return new PagableListResult<GetPostsResult>
            {
                Results = _mapper.Map<List<GetPostsResult>>(posts.Results),
                TotalCount = posts.TotalCount
            };
        }
    }
}