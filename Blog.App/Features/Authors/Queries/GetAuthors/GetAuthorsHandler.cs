using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Repositories;
using Blog.Core.Resources;
using MediatR;

namespace Blog.App.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsHandler : IRequestHandler<GetAuthorsQuery, PagableListResult<GetAuthorsResult>>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public GetAuthorsHandler(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
        }

        public async Task<PagableListResult<GetAuthorsResult>> Handle(GetAuthorsQuery query, CancellationToken ct)
        {
            var authors = await _authorsRepository.GetMany(
                query.PageNr,
                query.PageSize,
                query.Filter,
                ct);

            return new PagableListResult<GetAuthorsResult>
            {
                Results = _mapper.Map<List<GetAuthorsResult>>(authors.Results),
                TotalCount = authors.TotalCount
            };
        }
    }
}