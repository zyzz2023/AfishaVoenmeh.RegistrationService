using AfishaVoenmeh.RegistrationService.Domain.Common.Abstract;

namespace AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get; private set; }

    protected UserId() { } // EF Core

    private UserId(Guid value) => Value = value;

    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
