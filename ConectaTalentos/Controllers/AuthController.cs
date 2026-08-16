using ConectaTalentos.Application.DTOs.Account;
using Microsoft.AspNetCore.Mvc;

namespace ConectaTalentos.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            return Ok(user);
        }
    }
}
