using System;

namespace Blog.App.Resources
{
    public class IdResource
    {
        public Guid Id { get; set; }

        public IdResource(Guid id)
            => Id = id;
    }
}