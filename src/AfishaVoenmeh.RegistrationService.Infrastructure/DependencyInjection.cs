using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.RegistrationService.Infrastructure.Data;
using AfishaVoenmeh.RegistrationService.Infrastructure.Data.Common;
using AfishaVoenmeh.RegistrationService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AfishaVoenmeh.RegistrationService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationDbContext(configuration);

        services.AddScoped<IEventRegistrationRepository, EventRegistrationRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultPostgresConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
    }
}
