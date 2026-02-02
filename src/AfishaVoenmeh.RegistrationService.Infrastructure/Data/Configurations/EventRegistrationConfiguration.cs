using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate;
using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AfishaVoenmeh.RegistrationService.Infrastructure.Data.Configurations;

public class EventRegistrationConfiguration : IEntityTypeConfiguration<EventRegistration>
{
    public void Configure(EntityTypeBuilder<EventRegistration> builder)
    {
        builder.ToTable("EventRegistrations");

        builder.HasKey(e => e.Id);

        builder.OwnsOne(e => e.UserId, ub =>
        {
            ub.Property(u => u.Value)
              .HasColumnName("UserId")
              .IsRequired();
        });

        builder.OwnsOne(e => e.EventId, eb =>
        {
            eb.Property(e => e.Value)
              .HasColumnName("EventId")
              .IsRequired();
        });

        builder.Property(e => e.RegistrationStatus)
            .HasColumnName("RegistrationStatus")
            .IsRequired();

        builder.Property(e => e.RegisteredAt)
            .HasColumnName("RegisteredAt")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(e => e.CanceledAt)
            .HasColumnName("CancelledAt")
            .HasColumnType("timestamp with time zone");

        // Сделать уникальными пары EventId-UserId
    }
}