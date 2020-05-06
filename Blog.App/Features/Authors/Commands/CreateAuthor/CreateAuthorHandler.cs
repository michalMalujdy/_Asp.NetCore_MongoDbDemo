using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.App.Resources;
using Blog.Core.Domain.Models;
using Blog.Core.Repositories;
using MediatR;

namespace Blog.App.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, IdResource>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public CreateAuthorHandler(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
        }

        public async Task<IdResource> Handle(CreateAuthorCommand command, CancellationToken ct)
        {
            var author = _mapper.Map<Author>(command);
            author.SetInitialTimestamps();

            var id = await _authorsRepository.Create(author, ct);

            return new IdResource(id);
        }
    }
}