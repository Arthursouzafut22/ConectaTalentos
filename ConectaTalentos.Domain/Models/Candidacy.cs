using ConectaTalentos.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConectaTalentos.Domain.Models
{
    [Table("candidaturas")]
    public class Candidacy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Required]
        public int JobId { get; set; }

        [ForeignKey(nameof(JobId))]
        public Job? Job { get; set; }

        [Required]
        public string CurriculumUrl { get; set; } = string.Empty;

        [Required]
        public ApplicationStatus Status { get; set; } = ApplicationStatus.CurriculoEnviado;
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;

    }
}
