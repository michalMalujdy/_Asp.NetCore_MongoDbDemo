using System.Reflection;

namespace Blog.App.Infrastructure
{
    public static class AppAssemblyMarker
    {
        public static Assembly GetAssembly()
            => typeof(AppAssemblyMarker).Assembly;
    }
}