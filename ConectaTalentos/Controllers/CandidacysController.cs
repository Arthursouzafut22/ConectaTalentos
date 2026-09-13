using ConectaTalentos.Application.DTOs.Candidacys;
using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Domain.Enums;
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

        [Authorize]
        [HttpGet("minhas-candidaturas")]
        public async Task<IActionResult> MyCandidacys()
        {
            var userId = User.FindFirst("id")?.Value
                ?? throw new InvalidOperationException("ID do usuário não encontrado.");

            var myCandidacys = await _service.MyCandidacys(int.Parse(userId));
            return StatusCode(myCandidacys.StatusCode, myCandidacys);
        }

        [Authorize]
        [HttpGet("{id}/curriculo/baixar-pdf")]
        public async Task<IActionResult> DownloadCurriculum(int id)
        {
            var userId = User.FindFirst("id")?.Value
                ?? throw new InvalidOperationException("ID do usuário não encontrado.");
            var url = await _service.DownloadCurriculum(id, int.Parse(userId));

            return StatusCode(url.StatusCode, url);
        }

        [Authorize(Roles = nameof(UserRole.Recruiter))]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdatStatusCandidacys(int id, [FromBody] UpdatStatusDTO dto)
        {
            return StatusCode(200);
        }
    }
}
