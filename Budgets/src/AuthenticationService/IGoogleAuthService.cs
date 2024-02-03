namespace AuthenticationService;

public interface IGoogleAuthService
{
    Task<string> GetEmailFromGoogleAsync(string authorizationCode);
}