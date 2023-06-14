namespace JobBoard.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Register(string companyName, string email, string password);
        AuthenticationResult Login(string email, string password);
    }
}
