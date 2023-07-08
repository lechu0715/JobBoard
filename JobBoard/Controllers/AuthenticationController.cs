using JobBoard.Application.Services.Authentication.Commands;
using JobBoard.Application.Services.Authentication.Queries;
using JobBoard.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationCommandService = authenticationCommandService;
            _authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationCommandService.Register(request.CompanyName, request.Email, request.Password);

            var response = new AuthenticationResponse(
                authResult.CompanyUser.Id,
                authResult.CompanyUser.CompanyName,
                authResult.CompanyUser.Email,
                authResult.Token);
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationQueryService.Login(request.Email, request.Password);

            var response = new AuthenticationResponse(
                authResult.CompanyUser.Id,
                authResult.CompanyUser.CompanyName,
                authResult.CompanyUser.Email,
                authResult.Token);
            return Ok(response);
        }
    }
}
