using System.Reflection;

namespace Blog.Data.Infrastructure
{
    public static class DataAssemblyMarker
    {
        public static Assembly GetAssembly
            => typeof(DataAssemblyMarker).Assembly;
    }
}