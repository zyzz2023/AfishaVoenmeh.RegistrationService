using AfishaVoenmeh.RegistrationService.Application.Features.EventRegistration.Commands.Register;
using AfishaVoenmeh.RegistrationService.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AfishaVoenmeh.RegistrationService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventRegistrationsController : ApiController
{
    private readonly ISender _mediator;

    public EventRegistrationsController(ISender sender)
    {
        _mediator = sender;
    }

    [Authorize]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterEvent(Guid eventId)
    {
        var command = new RegisterEventCommand(eventId);

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
