using ConectaTalentos.Application.DTOs.Jobs;
using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

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
            return StatusCode(jobs.StatusCode, jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdJobs([FromRoute] GetJobRequestDTO dto)
        {
            var job = await _service.GetById(dto.Id);
            return StatusCode(job.StatusCode, job);
        }

        [Authorize(Roles = nameof(UserRole.Recruiter))]
        [HttpGet("minhas")]
        public async Task<IActionResult> GetMyJobs()
        {
            var userId = User.FindFirst("id")?.Value ?? throw new InvalidOperationException("");
            var myJobs = await _service.GetMyJobs(int.Parse(userId));
            return StatusCode(myJobs.StatusCode, myJobs);
        }

        [Authorize(Roles = nameof(UserRole.Recruiter))]
        [HttpPost("publicar-vaga")]
        [EnableRateLimiting("PublicarVaga")]
        public async Task<IActionResult> CreateJob([FromBody] CreteJobsDTO dto)
        {
            var userId = User.FindFirst("id")?.Value ?? throw new InvalidOperationException("");
            var job = await _service.CreteJob(dto, int.Parse(userId));
            return StatusCode(job.StatusCode, job);
        }

        [Authorize(Roles = nameof(UserRole.Recruiter))]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateJobs([FromBody] UpdateJob dto, int id)
        {
            var job = await _service.UpdateJob(id, dto);
            return StatusCode(job.StatusCode, job);
        }
    }
}
