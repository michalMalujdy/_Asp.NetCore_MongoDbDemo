using Blog.Core.Domain.Models;
using Blog.Data.DbModels;
using MongoDB.Driver;

namespace Blog.Data.Repositories.Posts
{
    public static class PostRepositoryExtension
    {
        public static IAggregateFluent<PostCompleteDbModel> IncludeAll(
            this IMongoCollection<Post> postsCollection,
            IMongoCollection<Author> authorsCollection,
            IMongoCollection<Comment> commentsCollection,
            IClientSessionHandle session)
            => postsCollection
                .Aggregate(session)
                .IncludeAuthors(authorsCollection)
                .IncludeComments(commentsCollection);


        public static IAggregateFluent<PostCompleteDbModel> IncludeAuthors(
            this IAggregateFluent<Post> aggregate,
            IMongoCollection<Author> authorsCollection)
            => aggregate
                .Lookup<Post, Author, PostCompleteDbModel>(
                    authorsCollection,
                    post => post.AuthorId,
                    author => author.Id,
                    model => model.Authors
                );

        public static IAggregateFluent<PostCompleteDbModel> IncludeComments(
            this IAggregateFluent<PostCompleteDbModel> aggregate,
            IMongoCollection<Comment> commentsCollection)
            => aggregate
                .Lookup<PostCompleteDbModel, Comment, PostCompleteDbModel>(
                    commentsCollection,
                    post => post.Id,
                    comment => comment.PostId,
                    model => model.Comments
                );
    }
}