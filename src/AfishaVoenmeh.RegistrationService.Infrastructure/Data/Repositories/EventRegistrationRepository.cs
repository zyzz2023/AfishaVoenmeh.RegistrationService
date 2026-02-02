using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate;

namespace AfishaVoenmeh.RegistrationService.Infrastructure.Data.Repositories;

public class EventRegistrationRepository : Repository<EventRegistration>, IEventRegistrationRepository
{
    public EventRegistrationRepository(ApplicationDbContext context) : base(context) { }
}
