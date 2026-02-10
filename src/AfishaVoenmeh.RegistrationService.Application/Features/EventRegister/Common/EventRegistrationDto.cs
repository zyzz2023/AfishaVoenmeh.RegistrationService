namespace AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Common;

public class EventRegistrationDto
{
    public Guid Id { get; init; }
    public Guid EventId { get; init; }
    public Guid UserId { get; init; }
    public int Status { get; init; }
    public DateTime RegisteredAt { get; init; }
    public DateTime? CanceledAt { get; init; }
}
