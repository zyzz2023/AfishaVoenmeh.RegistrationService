namespace AfishaVoenmeh.RegistrationService.Application.Common.Interfaces.Identity;

public interface ICurrentUser
{
    public Guid UserId { get; }
    public string Role { get; }
    public bool IsAuthenticated { get; }
}
