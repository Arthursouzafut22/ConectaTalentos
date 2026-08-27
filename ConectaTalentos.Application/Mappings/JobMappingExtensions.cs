using ConectaTalentos.Application.DTOs.Jobs;
using ConectaTalentos.Domain.Models;

namespace ConectaTalentos.Application.Mappings
{
    public static class JobMappingExtensions
    {
        public static Job ToEntity(this CreteJobsDTO dto, int userId)
        {
            return new Job
            {
                RecruiterId = userId,
                Title = dto.Title,
                CompanyName = dto.CompanyName,
                CompanyDescription = dto.CompanyDescription,
                DesiredTechnologies = dto.DesiredTechnologies,
                Location = dto.Location,
                Salary = dto.Salary,
                ContractType = dto.ContractType,
                WorkMode = dto.WorkMode,
                Description = dto.Description,
                Benefits = dto.Benefits,
                Requirements = dto.Requirements,
                IsActive = dto.IsActive,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static JobResponseDTO ToResponseDTO(this Job job)
        {
            return new JobResponseDTO
            {
                RecruiterId = job.RecruiterId,
                Title = job.Title,
                CompanyName = job.CompanyName,
                CompanyDescription = job.CompanyDescription,
                DesiredTechnologies = job.DesiredTechnologies,
                Location = job.Location,
                Salary = job.Salary,
                ContractType = job.ContractType,
                WorkMode = job.WorkMode,
                Description = job.Description,
                Benefits = job.Benefits,
                Requirements = job.Requirements,
                IsActive = job.IsActive
            };
        }
    }
}
