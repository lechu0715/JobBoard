using JobBoard.Domain.Entities;

namespace JobBoard.Application.Authentication.Common
{
    public record AuthenticationResult(CompanyUser CompanyUser, string Token);
}