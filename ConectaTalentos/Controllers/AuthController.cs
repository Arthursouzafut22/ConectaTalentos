using ConectaTalentos.Application.DTOs.Account;
using ConectaTalentos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConectaTalentos.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
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
    }
}
