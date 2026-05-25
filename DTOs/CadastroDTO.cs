using System.ComponentModel.DataAnnotations;

namespace CLINICAINOVA.DTOs
{
    public class CadastroDTO
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Senha { get; set; } = string.Empty;

        public string Perfil { get; set; } = "Paciente";

        [Required]
        public string Cpf { get; set; } = string.Empty;

        [Required]
        public string Telefone { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }
    }
}