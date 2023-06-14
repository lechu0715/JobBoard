using JobBoard.Application.Common.Interfaces.Authentication;
using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Domain.Entities;

namespace JobBoard.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ICompanyUserRepository _companyUserRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, ICompanyUserRepository companyUserRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _companyUserRepository = companyUserRepository;
        }

        public AuthenticationResult Register(string companyName, string email, string password)
        {
            if (_companyUserRepository.GetCompanyUserByEmail(email) is not null)
            {
                throw new Exception("Company with given email already exist.");
            }

            var companyUser = new CompanyUser { CompanyName = companyName, Email = email, Password = password };
            _companyUserRepository.Add(companyUser);

            var token = _jwtTokenGenerator.GenerateToken(companyUser.Id, companyName);

            return new AuthenticationResult(companyUser.Id, companyName, email, token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            if (_companyUserRepository.GetCompanyUserByEmail(email) is not CompanyUser companyUser)
            {
                throw new Exception("Company with given email does not exist.");
            }

            if (companyUser.Password != password)
            {
                throw new Exception("Invalid Password.");
            }

            var token = _jwtTokenGenerator.GenerateToken(companyUser.Id, companyUser.CompanyName);

            return new AuthenticationResult(companyUser.Id, companyUser.CompanyName, email, token);
        }
    }
}
