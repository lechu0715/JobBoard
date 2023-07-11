using ErrorOr;
using JobBoard.Application.Common.Interfaces.Authentication;
using JobBoard.Application.Common.Interfaces.Persistence;
using MediatR;
using JobBoard.Domain.Common.Errors;
using JobBoard.Domain.Entities;
using JobBoard.Application.Authentication.Common;

namespace JobBoard.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ICompanyUserRepository _companyUserRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, ICompanyUserRepository companyUserRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _companyUserRepository = companyUserRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (_companyUserRepository.GetCompanyUserByEmail(query.Email) is not CompanyUser companyUser)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (companyUser.Password != query.Password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }

            var token = _jwtTokenGenerator.GenerateToken(companyUser);

            return new AuthenticationResult(companyUser, token); 
        }
    }
}