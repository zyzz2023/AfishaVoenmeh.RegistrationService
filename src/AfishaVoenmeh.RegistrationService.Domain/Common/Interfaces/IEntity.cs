namespace AfishaVoenmeh.RegistrationService.Domain.Common.Interfaces;

public interface IEntity<TId>
{
    TId Id { get; }
}
