using ConectaTalentos.Application.DTOs.Jobs;
using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConectaTalentos.Controllers
{
    [ApiController]
    [Route("v1/vagas")]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _service;

        public JobsController(IJobsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _service.GetAll();
            return Ok(jobs);
        }


        [Authorize(Roles = nameof(UserRole.Recruiter))]
        [HttpPost("publicar-vaga")]
        public async Task<IActionResult> CreateJob([FromBody] CreteJobsDTO dto)
        {
            var userId = User.FindFirst("id")?.Value ?? throw new InvalidOperationException("");
            var job = await _service.CreteJob(dto, int.Parse(userId));
            return Ok(job);
        }
    }
}
