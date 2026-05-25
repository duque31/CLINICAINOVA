namespace CLINICAINOVA.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public string Perfil { get; set; } = "Paciente";

        public string Cpf { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }
    }
}