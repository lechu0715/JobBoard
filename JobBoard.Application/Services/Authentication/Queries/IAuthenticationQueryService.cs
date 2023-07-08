using JobBoard.Application.Services.Authentication.Common;

namespace JobBoard.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        AuthenticationResult Login(string email, string password);
    }
}
