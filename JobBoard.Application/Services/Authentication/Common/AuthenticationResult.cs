using JobBoard.Domain.Entities;

namespace JobBoard.Application.Services.Authentication.Common
{
    public record AuthenticationResult(
        CompanyUser CompanyUser,
        string Token);
}
