using Microsoft.AspNetCore.Mvc;
using BlazorAuthDemo.Models;
using BlazorAuthDemo.Services;

namespace BlazorAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public AuthController(IAuthenticationService authService) => _authService = authService;

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (_authService.Authenticate(model.Username, model.Password))
                return Ok();
            return Unauthorized();
        }
    }
}
