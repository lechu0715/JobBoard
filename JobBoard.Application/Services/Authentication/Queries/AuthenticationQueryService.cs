using JobBoard.Application.Common.Interfaces.Authentication;
using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Application.Services.Authentication.Common;
using JobBoard.Domain.Entities;

namespace JobBoard.Application.Services.Authentication.Queries
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ICompanyUserRepository _companyUserRepository;

        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, ICompanyUserRepository companyUserRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _companyUserRepository = companyUserRepository;
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

            var token = _jwtTokenGenerator.GenerateToken(companyUser);

            return new AuthenticationResult(companyUser, token);
        }
    }
}
