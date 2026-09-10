using ConectaTalentos.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConectaTalentos.Controllers
{
    [ApiController]
    [Route("v1/candidaturas")]
    public class CandidacysController : ControllerBase
    {
        private readonly ICandidacyService _service;

        public CandidacysController(ICandidacyService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("vagas/{jobId}/candidatar")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Apply(int jobId, IFormFile file)
        {
            var userId = User.FindFirst("id")?.Value
                ?? throw new InvalidOperationException("ID do usuário não encontrado.");
            var apply = await _service.Apply(jobId, int.Parse(userId), file);

            return StatusCode(apply.StatusCode, apply);
        }
    }
}
