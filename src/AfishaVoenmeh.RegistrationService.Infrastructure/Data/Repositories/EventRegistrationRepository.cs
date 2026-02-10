using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate;
using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AfishaVoenmeh.RegistrationService.Infrastructure.Data.Repositories;

public class EventRegistrationRepository : Repository<EventRegistration>, IEventRegistrationRepository
{
    public EventRegistrationRepository(ApplicationDbContext context) : base(context) { }

    public async Task<bool> IsRegistrationExsistsAsync(EventId eventId, UserId userId)
    {
        return await _context.EventRegistrations
            .AsNoTracking()
            .AnyAsync(x => 
            x.UserId.Value == userId.Value && 
            x.EventId.Value == eventId.Value);
    }
}
