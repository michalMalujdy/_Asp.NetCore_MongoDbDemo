using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Blog.Api.ConfigurationExtensions
{
    public static class ConfigureSwaggerExtension
    {
        public static IServiceCollection ConfigureSwagger (
            this IServiceCollection services,
            string projectName = null,
            string xmlDocumentationFileName = null,
            string description = null)
        {
            services.AddSwaggerGen(c =>
            {
                var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
                projectName = projectName ?? assemblyName;
                xmlDocumentationFileName ??= $"{assemblyName}.xml";

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{projectName} API",
                    Version = "v1",
                    Description = description
                });

                // IMPORTANT: remember to setup generating documentation from XML comments for the project
                IncludeDocumentationFile(c, xmlDocumentationFileName);

                c.CustomSchemaIds(type => type.FullName);
                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();
            });

            return services;
        }

        private static void IncludeDocumentationFile(SwaggerGenOptions c, string filename)
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            var path = Path.Combine(Path.GetDirectoryName(entryAssembly.Location), filename);
            c.IncludeXmlComments(path);
        }

        public static void UseSwagger(this IApplicationBuilder app)
        {
            SwaggerBuilderExtensions.UseSwagger(app);

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });
        }
    }
}