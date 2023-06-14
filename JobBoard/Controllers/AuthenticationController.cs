using JobBoard.Application.Services.Authentication;
using JobBoard.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(request.CompanyName, request.Email, request.Password);

            var response = new AuthenticationResponse(authResult.Id, authResult.CompanyName, authResult.Email, authResult.Token);
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);

            var response = new AuthenticationResponse(authResult.Id, authResult.CompanyName, authResult.Email, authResult.Token);
            return Ok(response);
        }
    }
}
