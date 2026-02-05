namespace AfishaVoenmeh.RegistrationService.Infrastructure.Authentication.Common;

public class JwtOptions
{
    public const string Section = "JwtOptions";
    public const string IssuerSection = "JwtOptions:Issuer";
    public const string AudienceSection = "JwtOptions:Audience";
    public const string IssuerSigningKeySection = "JwtOptions:SecretKey";

    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string Expire { get; set; } = null!;
    public string ExpireRefreshToken { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
}
