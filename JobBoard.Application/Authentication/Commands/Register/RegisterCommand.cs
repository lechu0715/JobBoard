using ErrorOr;
using JobBoard.Application.Authentication.Common;
using MediatR;

namespace JobBoard.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string CompanyName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
