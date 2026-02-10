using AfishaVoenmeh.RegistrationService.Application.Common.Mappings;
using AfishaVoenmeh.RegistrationService.WebAPI.Common.Handlers;
using Mapster;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AfishaVoenmeh.RegistrationService.WebAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddConfiguredSwagger();

        services.AddConfiguredMapster();

        services.AddGlobalExceptionHandler();

        return services;
    }

    private static void AddConfiguredMapster(this IServiceCollection services)
    {
        var applicationAssembly = typeof(EventRegistrationMappingConfiguration).Assembly;

        var configuration = TypeAdapterConfig.GlobalSettings;
        configuration.Scan(applicationAssembly);

        services.AddSingleton(configuration);
        services.AddMapster();
    }

    private static IServiceCollection AddConfiguredSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "RegistrationService (AfishaVoenmeh)",
                Version = "v1",
                Description = "A microservice for registration to events."
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Введите JWT access token"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
                });

        return services;
    }

    private static void AddGlobalExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
            };
        });
    }
}
