namespace CLINICAINOVA.Models
{
    public class Prontuario
    {
        public int Id { get; set; }

        public string EvolucaoClinica { get; set; } = string.Empty;

        public string? Prescricao { get; set; }

        public string? Exames { get; set; }

        public DateTime DataRegistro { get; set; } = DateTime.Now;

        // Relacionamento

        public int AgendamentoId { get; set; }

        public Agendamento? Agendamento { get; set; }
    }
}