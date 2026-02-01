using FluentValidation;

namespace AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Commands.Register;

public class RegisterEventCommandValidator : AbstractValidator<RegisterEventCommand>
{
    public RegisterEventCommandValidator()
    {
        RuleFor(x => x.EventId)
            .Must(eventId => eventId != Guid.Empty)
            .WithMessage("EventId must not be empty.");

        RuleFor(x => x.UserId)
            .Must(userId => userId != Guid.Empty)
            .WithMessage("UserId must not be empty.");
    }
}
