using ConectaTalentos.Application.DTOs.Account;
using ConectaTalentos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConectaTalentos.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO dto)
        {
            var user = await _service.RegisterAsync(dto);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var login = await _service.LoginAsync(dto);
            return Ok(login);
        }
    }
}
