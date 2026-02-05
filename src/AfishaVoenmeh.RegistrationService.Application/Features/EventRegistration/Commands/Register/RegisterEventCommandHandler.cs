using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Identity;
using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Common;
using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Commands.Register;

public class RegisterEventCommandHandler
    : IRequestHandler<RegisterEventCommand, ErrorOr<EventRegistrationDto>>
{
    //private readonly IEventRegistrationRepository _eventRegistrationRepository;
    private readonly ICurrentUser _currentUser;

    public RegisterEventCommandHandler(ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }

    public async Task<ErrorOr<EventRegistrationDto>> Handle(RegisterEventCommand command, CancellationToken cancellationToken)
    {
        if (!_currentUser.IsAuthenticated)
            return Error.Unauthorized();

        Console.WriteLine($"User {_currentUser.UserId} is registering for event {command.EventId}");
        // Проверка дупликата этой регистрации

        // Получение информации о Event через IEventServiceClient

        // Проверка статуса мероприятия

        // Проверка соответствия Role пользователя и Targer мероприятия

        // Резервирование места на мероприятии через IEventServiceClient (Добавить ендпоинты в EventService)

        // Создание EventRegistration

        // Сохранение EventRegistration в БД (Добавить UnitOfWork, Подумать о валидации сохранения в БД)
        
        return new EventRegistrationDto
        {
            Id = Guid.NewGuid(),
            EventId = command.EventId,
            UserId = _currentUser.UserId,
            Status = 1, // Registered
            RegisteredAt = DateTime.UtcNow,
            CanceledAt = null
        };
    }
}
