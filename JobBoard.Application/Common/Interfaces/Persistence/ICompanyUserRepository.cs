using JobBoard.Domain.Entities;

namespace JobBoard.Application.Common.Interfaces.Persistence
{
    public interface ICompanyUserRepository
    {
        CompanyUser GetCompanyUserByEmail(string email);
        void Add(CompanyUser companyUser);
    }
}
