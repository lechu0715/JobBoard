using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Domain.Entities;

namespace JobBoard.Infrastructure.Persistence
{
    public class CompanyUserRepository : ICompanyUserRepository
    {
        private static readonly List<CompanyUser> _companyUsers = new();

        public void Add(CompanyUser companyUser)
        {
            _companyUsers.Add(companyUser);
        }

        public CompanyUser GetCompanyUserByEmail(string email)
        {
            return _companyUsers.SingleOrDefault(x => x.Email == email);
        }
    }
}
