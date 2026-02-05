using FluentValidation;

namespace AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Commands.Register;

public class RegisterEventCommandValidator : AbstractValidator<RegisterEventCommand>
{
    public RegisterEventCommandValidator()
    {
        RuleFor(x => x.EventId)
            .Must(eventId => eventId != Guid.Empty)
            .WithMessage("EventId must not be empty.");
    }
}
