using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate;
using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate.ValueObjects;

namespace AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Persistence;

public interface IEventRegistrationRepository : IRepository<EventRegistration>
{
    Task<bool> IsRegistrationExsistsAsync(EventId eventId, UserId userId);
}
