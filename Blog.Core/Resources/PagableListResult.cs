using System.Collections.Generic;

namespace Blog.Core.Resources
{
    public class PagableListResult<TModel>
    {
        public List<TModel> Results { get; set; }
        public long TotalCount { get; set; }
    }
}