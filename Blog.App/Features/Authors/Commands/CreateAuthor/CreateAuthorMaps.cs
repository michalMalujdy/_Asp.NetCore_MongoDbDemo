using AutoMapper;
using Blog.Core.Domain.Models;

namespace Blog.App.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorMaps : Profile
    {
        public CreateAuthorMaps()
        {
            CreateMap<CreateAuthorCommand, Author>();
        }
    }
}