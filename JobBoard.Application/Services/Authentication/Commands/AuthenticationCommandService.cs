using JobBoard.Application.Common.Interfaces.Authentication;
using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Application.Services.Authentication.Common;
using JobBoard.Domain.Entities;

namespace JobBoard.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ICompanyUserRepository _companyUserRepository;

        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, ICompanyUserRepository companyUserRepository)
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

            var token = _jwtTokenGenerator.GenerateToken(companyUser);

            return new AuthenticationResult(companyUser, token);
        }
    }
}
