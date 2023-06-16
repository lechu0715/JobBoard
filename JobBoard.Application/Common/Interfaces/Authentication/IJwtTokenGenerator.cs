using JobBoard.Domain.Entities;

namespace JobBoard.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(CompanyUser companyUser);
    }
}
