using AfishaVoenmeh.RegistrationService.Domain.Common.Abstract;

namespace AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate.ValueObjects;

public class EventId : ValueObject
{
    public Guid Value { get; private set; }

    protected EventId() { } // EF Core

    private EventId(Guid value) => Value = value;

    public static EventId Create(Guid value)
    {
        return new EventId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
