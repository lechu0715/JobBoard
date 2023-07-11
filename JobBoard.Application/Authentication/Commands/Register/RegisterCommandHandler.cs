using ErrorOr;
using JobBoard.Application.Common.Interfaces.Authentication;
using JobBoard.Application.Common.Interfaces.Persistence;
using MediatR;
using JobBoard.Domain.Common.Errors;
using JobBoard.Domain.Entities;
using JobBoard.Application.Authentication.Common;

namespace JobBoard.Application.Authentication.Commands.Register
{
    public class LoginQueryHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ICompanyUserRepository _companyUserRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, ICompanyUserRepository companyUserRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _companyUserRepository = companyUserRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (_companyUserRepository.GetCompanyUserByEmail(command.Email) is not null)
            {
                return Errors.CompanyUser.DuplicateEmail;
            }

            var companyUser = new CompanyUser
            {
                CompanyName = command.CompanyName,
                Email = command.Email,
                Password = command.Password
            };
            _companyUserRepository.Add(companyUser);

            var token = _jwtTokenGenerator.GenerateToken(companyUser);

            return new AuthenticationResult(companyUser, token);
        }
    }
}