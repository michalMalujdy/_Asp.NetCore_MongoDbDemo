// using System.Threading;
// using System.Threading.Tasks;
// using Blog.Core.Repositories.PostsRepository;
// using MediatR;
//
// namespace Blog.App.Features.Posts.Queries.GetPost
// {
//     public class GetPostHandler : IRequestHandler<GetPostQuery, GetPostResult>
//     {
//         private readonly IPostsRepository _postsRepository;
//
//         public GetPostHandler(IPostsRepository postsRepository)
//             => _postsRepository = postsRepository;
//
//         public async Task<GetPostResult> Handle(GetPostQuery query, CancellationToken ct)
//         {
//             var post = await _postsRepository.GetPostWithAuthor(query.PostId);
//         }
//     }
// }