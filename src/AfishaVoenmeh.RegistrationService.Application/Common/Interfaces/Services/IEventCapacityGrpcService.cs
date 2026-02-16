using ErrorOr;

namespace AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Services;

public interface IEventCapacityGrpcService 
{
    Task<ErrorOr<bool>> ReserveSeatOnEventAsync(Guid eventId, string userRole, CancellationToken cancellationToken);
    Task<ErrorOr<bool>> ReleaseSeatOnEventAsync(Guid eventId, CancellationToken cancellationToken);
}
