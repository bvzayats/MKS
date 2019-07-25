using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace NedoNet.API.Extensions {
    public static class SwaggerServiceExtensions {
        private static readonly string Version = "v1.0";
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services) {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc(Version, new Info { Title = $"BankingApp.API {Version}", Version = Version });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint($"/swagger/{Version}/swagger.json", $"Versioned API {Version}");

                c.DocumentTitle = "Users API";
                c.DocExpansion(DocExpansion.None);
            });

            return app;
        }

    }
}