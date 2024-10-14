using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence.EF.Context;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RamandTask.DI;

public static class RegisterDependencies
{
    public static WebApplicationBuilder RegisterAutoFac
        (this WebApplicationBuilder builder, ConfigureHostBuilder hostBuilder)
    {
        hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        hostBuilder.ConfigureContainer<ContainerBuilder>(
            containerBuilder => containerBuilder.RegisterModule(new AutofacModule()));

        return builder;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection service)
        => service.RegisterDatabase();

    public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddOptions<SwaggerGenOptions>().Configure(swagger =>
        {
            var swaggerDocOptions = new SwaggerDocumentOptions();
            configuration.GetSection(nameof(SwaggerDocumentOptions)).Bind(swaggerDocOptions);
            swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });
    }



    public class SwaggerDocumentOptions
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organization { get; set; }
        public string Email { get; set; }
        public string Version { get; set; }
    }
}