using ErrorOr; 
using JobBoard.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using JobBoard.Domain.Common.Errors;
using JobBoard.Application.Authentication.Commands.Register;
using JobBoard.Application.Authentication.Common;
using JobBoard.Application.Authentication.Queries.Login;

namespace JobBoard.API.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.CompanyName, request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                            authResult.CompanyUser.Id,
                            authResult.CompanyUser.CompanyName,
                            authResult.CompanyUser.Email,
                            authResult.Token);
        }
    }
}
