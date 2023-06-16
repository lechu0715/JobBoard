using JobBoard.Domain.Entities;

namespace JobBoard.Application.Services.Authentication
{
    public record AuthenticationResult(
        CompanyUser CompanyUser,
        string Token);
}
