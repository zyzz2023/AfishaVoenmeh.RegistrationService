namespace AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate.Enums;

public enum RegistrationStatus
{
    Active = 1,
    Cancelled = 2,
    Attended = 3, // Посещенный
    Skipped = 4 // Пропущенный
}
