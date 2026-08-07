using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConectaTalentos.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> register()
        {
            return Ok();
        }
    }
}
