using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Identity;
using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Services;
using AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Common;
using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate.ValueObjects;
using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;

namespace AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Commands.Register;

public class RegisterEventCommandHandler
    : IRequestHandler<RegisterEventCommand, ErrorOr<EventRegistrationDto>>
{
    private readonly IEventRegistrationRepository _eventRegistrationRepository;
    private readonly IEventCapacityGrpcService _eventCapacityGrpcService;
    private readonly ICurrentUser _currentUser;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterEventCommandHandler(
        ICurrentUser currentUser,
        IUnitOfWork unitOfWork,
        IEventRegistrationRepository eventRegistrationRepository,
        IEventCapacityGrpcService eventCapacityGrpcService,
        IMapper mapper)
    {
        _currentUser = currentUser;
        _unitOfWork = unitOfWork;
        _eventRegistrationRepository = eventRegistrationRepository;
        _mapper = mapper;
        _eventCapacityGrpcService = eventCapacityGrpcService;
    }

    public async Task<ErrorOr<EventRegistrationDto>> Handle(RegisterEventCommand command, CancellationToken cancellationToken)
    {
        if (!_currentUser.IsAuthenticated)
            return Error.Unauthorized("UNAUTHORIZED","Authorization is required to register for the event.");

        var userId = UserId.Create(_currentUser.UserId);
        var eventId = EventId.Create(command.EventId);

        if(await _eventRegistrationRepository.IsRegistrationExsistsAsync(eventId, userId))
            return Error.Validation("REGISTRATION_EXISTS", "Registration already exsists.");

        // Создание EventRegistration
        var eventRegistration = Domain.EventRegistrationAggregate.EventRegistration.Create(userId, eventId);

        // Сохранение EventRegistration в БД (Добавить UnitOfWork, Подумать о валидации сохранения в БД)
        await _eventRegistrationRepository.AddAsync(eventRegistration, cancellationToken);

        // Резервирование места на мероприятии через IEventServiceClient (передать Role)
        var grpcResult = await _eventCapacityGrpcService.ReserveSeatOnEventAsync(eventId.Value, _currentUser.Role,cancellationToken);
        if(grpcResult.IsError)
        {
            return grpcResult.Errors;
        }

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<EventRegistrationDto>(eventRegistration);
    }
}
