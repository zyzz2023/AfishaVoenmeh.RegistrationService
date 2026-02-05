using AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AfishaVoenmeh.RegistrationService.Infrastructure.Identity;

public class CurrentUser : ICurrentUser
{
    public Guid UserId { get; } = Guid.Empty;

    public string Role { get; } = string.Empty;

    public bool IsAuthenticated { get; } = false;

    public CurrentUser(IHttpContextAccessor accessor)
    {
        var user = accessor.HttpContext?.User;

        IsAuthenticated = user?.Identity?.IsAuthenticated ?? false;
        if (!IsAuthenticated)
            return;

        UserId = Guid.Parse(
            user?.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        Role = user?.FindFirst(ClaimTypes.Role)!.Value;
    }
}
