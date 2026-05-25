namespace CLINICAINOVA.Models
{
    public class ProfissionalSaude : Usuario
    {
        public string Especialidade { get; set; } = string.Empty;

        public List<Agendamento>? Consultas { get; set; }
    }
}