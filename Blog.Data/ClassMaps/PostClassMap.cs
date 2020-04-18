using Blog.Core.Domain.Models;
using MongoDB.Bson.Serialization;

namespace Blog.Data.ClassMaps
{
    public class PostClassMap
    {
        public PostClassMap()
        {
            BsonClassMap.RegisterClassMap<Post>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(post => post.Id);
            });
        }
    }
}