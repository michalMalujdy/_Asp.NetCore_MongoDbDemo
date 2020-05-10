using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.App.Features.Common.Author;
using Blog.Core.Repositories;
using Blog.Core.Resources;
using MediatR;

namespace Blog.App.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsHandler : IRequestHandler<GetAuthorsQuery, PagableListResult<AuthorCommonResult>>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public GetAuthorsHandler(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
        }

        public async Task<PagableListResult<AuthorCommonResult>> Handle(GetAuthorsQuery query, CancellationToken ct)
        {
            var authors = await _authorsRepository.GetMany(
                query.PageNr,
                query.PageSize,
                query.Filter,
                ct);

            return new PagableListResult<AuthorCommonResult>
            {
                Results = _mapper.Map<List<AuthorCommonResult>>(authors.Results),
                TotalCount = authors.TotalCount
            };
        }
    }
}