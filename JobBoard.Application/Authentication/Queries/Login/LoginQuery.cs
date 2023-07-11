using ErrorOr;
using JobBoard.Application.Authentication.Common;
using MediatR;

namespace JobBoard.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
