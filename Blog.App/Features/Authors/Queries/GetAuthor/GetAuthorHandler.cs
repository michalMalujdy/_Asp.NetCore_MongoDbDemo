using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Repositories;
using MediatR;

namespace Blog.App.Features.Authors.Queries.GetAuthor
{
    public class GetAuthorHandler : IRequestHandler<GetAuthorQuery, GetAuthorResult>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public GetAuthorHandler(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
        }

        public async Task<GetAuthorResult> Handle(GetAuthorQuery query, CancellationToken ct)
        {
            var author = await _authorsRepository.Get(query.AuthorId, ct);

            return _mapper.Map<GetAuthorResult>(author);
        }
    }
}