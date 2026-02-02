using AfishaVoenmeh.RegistrationService.WebAPI.Controllers.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AfishaVoenmeh.RegistrationService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventRegistrationsController : ApiController
{

    [HttpPost("register")]
    public IActionResult RegisterEvent()
    {
        // Вытаскивание UserId и Role из JWT

        return Ok();
    }
}
