using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Common;
using ErrorOr;
using MediatR;

namespace AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Commands.Register;

public class RegisterEventCommandHandler
    : IRequestHandler<RegisterEventCommand, ErrorOr<EventRegistrationDto>>
{
    private readonly IEventRegistrationRepository _eventRegistrationRepository;

    public RegisterEventCommandHandler(IEventRegistrationRepository eventRegistrationRepository)
    {
        _eventRegistrationRepository = eventRegistrationRepository;
    }

    public Task<ErrorOr<EventRegistrationDto>> Handle(RegisterEventCommand command, CancellationToken cancellationToken)
    {
        // Проверка дупликата этой регистрации

        // Получение информации о Event через IEventServiceClient

        // Проверка статуса мероприятия

        // Проверка соответствия Role пользователя и Targer мероприятия

        // Резервирование места на мероприятии через IEventServiceClient (Добавить ендпоинты в EventService)

        // Создание EventRegistration

        // Сохранение EventRegistration в БД (Добавить UnitOfWork, Подумать о валидации сохранения в БД)

        throw new NotImplementedException();
    }
}
