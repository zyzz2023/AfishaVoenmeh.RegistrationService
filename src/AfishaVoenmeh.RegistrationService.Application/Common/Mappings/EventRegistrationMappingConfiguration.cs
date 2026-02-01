using AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Common;
using AfishaVoenmeh.RegistrationService.Domain.EventRegistrationAggregate;
using Mapster;

namespace AfishaVoenmeh.RegistrationService.Application.Common.Mappings;

public class EventRegistrationMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EventRegistration, EventRegistrationDto>()
            .Map(dest => dest.EventId,
                src => src.EventId.Value)
            .Map(dest => dest.UserId,
                src => src.UserId.Value);
    }
}
