using AfishaVoenmeh.RegistrationService.Domain.Common.Abstract;
using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate.Enums;
using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate.ValueObjects;

namespace AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate;

public class EventRegistartion : AggregateRoot<Guid>
{
    public UserId UserId { get; private set; }   
    public EventId EventId { get; private set; }
    public RegistrationStatus RegistrationStatus { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public DateTime? CanceledAt { get; private set; }

    protected EventRegistartion() { } // EF Core

    private EventRegistartion(
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

    public static EventRegistartion Create(
        UserId userId, 
        EventId eventId, 
        RegistrationStatus registrationStatus, 
        DateTime registeredAt, 
        DateTime? canceledAt)
    {
        return new EventRegistartion(
            userId, 
            eventId, 
            registrationStatus, 
            registeredAt, 
            canceledAt);
    }
}
