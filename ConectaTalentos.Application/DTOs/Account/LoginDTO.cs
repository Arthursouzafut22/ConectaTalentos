using System.ComponentModel.DataAnnotations;

namespace ConectaTalentos.Application.DTOs.Account
{
    public class LoginDTO
    {
        [EmailAddress(ErrorMessage = "O campo E-mail não é um endereço de e-mail válido.")]
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve possuir no mínimo 6 caracteres.")]
        public string Password { get; set; } = string.Empty;
    }
}
