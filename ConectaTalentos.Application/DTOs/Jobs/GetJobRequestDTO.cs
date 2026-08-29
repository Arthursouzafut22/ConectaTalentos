using System.ComponentModel.DataAnnotations;

namespace ConectaTalentos.Application.DTOs.Jobs
{
    public class GetJobRequestDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "O Id deve ser um número válido maior que zero.")]
        public int Id { get; set; }
    }
}
