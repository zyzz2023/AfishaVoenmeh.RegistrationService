using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Services;
using AfishaVoenmeh.Shared.Contracts.Protos.Event;
using ErrorOr;

namespace AfishaVoenmeh.RegistrationService.Infrastructure.Grpc;

internal class EventCapacityGrpcService : IEventCapacityGrpcService
{
    private readonly EventCapacityService.EventCapacityServiceClient _client;

    public EventCapacityGrpcService(EventCapacityService.EventCapacityServiceClient client)
    {
        _client = client;
    }
    public async Task<ErrorOr<bool>> ReleaseSeatOnEventAsync(
        Guid eventId,
        CancellationToken cancellationToken)
    {
        var request = new ReleaseSeatRequest
        {
            EventId = eventId.ToString()
        };
        
        var response = await _client.ReleaseSeatAsync(
            request, 
            cancellationToken: cancellationToken);

        return response.Success ? true : Error.Failure("Error_To_Release_Seat", response.Message);
    }

    public async Task<ErrorOr<bool>> ReserveSeatOnEventAsync(
        Guid eventId, 
        string userRole, 
        CancellationToken cancellationToken)
    {
        var request = new ReserveSeatRequest
        {
            EventId = eventId.ToString(),
            UserRole = userRole
        };

        var response = await _client.ReserveSeatAsync(
            request,
            cancellationToken: cancellationToken);

        return response.Success ? true : Error.Failure("Error_To_Reserve_Seat", response.Message);
    }
}
