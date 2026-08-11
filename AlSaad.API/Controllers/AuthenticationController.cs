using AlSaad.Application.DTOs;
using AlSaad.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlSaad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO request)
        {
            var response = await _authenticationService.Register(request);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO request)
        {
            var response = await _authenticationService.Login(request);

            if (!response.Success)
                return Unauthorized(response);

            return Ok(response);

        }
    }
}
