using AfishaVoenmeh.RegistrationService.Domain.Common.Abstract;
using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate.Enums;
using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate.ValueObjects;

namespace AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate;

public class EventRegistration : AggregateRoot<Guid>
{
    public UserId UserId { get; private set; }   
    public EventId EventId { get; private set; }
    public RegistrationStatus RegistrationStatus { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public DateTime? CanceledAt { get; private set; }

    protected EventRegistration() { } // EF Core

    private EventRegistration(
        UserId userId, 
        EventId eventId, 
        RegistrationStatus registrationStatus, 
        DateTime registeredAt, 
        DateTime? canceledAt)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        EventId = eventId;
        RegistrationStatus = registrationStatus;
        RegisteredAt = registeredAt;
        CanceledAt = canceledAt;
    }

    public static EventRegistration Create(
        UserId userId, 
        EventId eventId, 
        RegistrationStatus registrationStatus, 
        DateTime registeredAt, 
        DateTime? canceledAt)
    {
        return new EventRegistration(
            userId, 
            eventId, 
            registrationStatus, 
            registeredAt, 
            canceledAt);
    }
}
