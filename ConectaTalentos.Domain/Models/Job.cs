using ConectaTalentos.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConectaTalentos.Domain.Models
{
    [Table("vagas")]
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RecruiterId { get; set; }

        [Required]
        [ForeignKey(nameof(RecruiterId))]
        public User? Recruiter { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string CompanyDescription { get; set; } = string.Empty;

        [Required]
        public string[] DesiredTechnologies { get; set; } = [];

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public ContractType ContractType { get; set; }

        [Required]
        public WorkMode WorkMode { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public List<string> Benefits { get; set; } = [];

        [Required]
        public List<string> Requirements { get; set; } = [];

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime? UpdatedAt { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
