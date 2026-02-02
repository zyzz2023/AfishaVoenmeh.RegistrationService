using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AfishaVoenmeh.RegistrationService.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<EventRegistration> EventRegistrations { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
