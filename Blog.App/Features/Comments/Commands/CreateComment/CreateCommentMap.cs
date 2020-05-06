using AutoMapper;
using Blog.Core.Domain.Models;

namespace Blog.App.Features.Comments.Commands.CreateComment
{
    public class CreateCommentMap : Profile
    {
        public CreateCommentMap()
        {
            CreateMap<CreateCommentCommand, Comment>();
        }
    }
}