using ConectaTalentos.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConectaTalentos.Controllers
{
    [ApiController]
    [Route("v1/perfil")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _service;

        public ProfileController(IProfileService service) => _service = service;

        [Authorize]
        [HttpGet("meu-perfil")]
        public async Task<IActionResult> MyProfile()
        {
            var userId = User.FindFirst("id")!.Value;
            var profile = await _service.MyProfile(int.Parse(userId));

            return StatusCode(profile.StatusCode, profile);
        }
    }
}
