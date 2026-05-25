namespace CLINICAINOVA.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        public DateTime DataHora { get; set; }

        public string Status { get; set; } = "Pendente";

        public bool RequerLibras { get; set; }

        public string? Justificativa { get; set; }

        // Relacionamentos

        public int PacienteId { get; set; }

        public Paciente? Paciente { get; set; }

        public int ProfissionalId { get; set; }

        public ProfissionalSaude? Profissional { get; set; }

        public int ServicoId { get; set; }

        public Servico? Servico { get; set; }
    }
}