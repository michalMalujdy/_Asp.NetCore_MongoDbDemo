using Blog.App.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api.ConfigurationExtensions
{
    public static class ConfigureCommandQuerySeparationExtension
    {
        public static void ConfigureCommandQuerySeparation(this IServiceCollection services)
            => services.AddMediatR(AppAssemblyMarker.GetAssembly());
    }
}