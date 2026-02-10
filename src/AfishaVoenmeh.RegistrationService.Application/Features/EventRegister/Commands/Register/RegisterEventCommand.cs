using AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Common;
using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Commands.Register;

public record RegisterEventCommand(Guid EventId) 
    : IRequest<ErrorOr<EventRegistrationDto>>;