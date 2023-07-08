using JobBoard.Application.Services.Authentication.Common;

namespace JobBoard.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        AuthenticationResult Register(string companyName, string email, string password);
        
    }
}

