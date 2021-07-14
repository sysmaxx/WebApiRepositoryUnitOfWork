using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Configuration
{
    public static class SwaggerConfigurator
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
            });
        }
    }
}
