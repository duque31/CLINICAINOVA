namespace CLINICAINOVA.DTOs
{
    public class ProntuarioDTO
    {
        public string EvolucaoClinica { get; set; } = string.Empty;

        public string? Prescricao { get; set; }

        public string? Exames { get; set; }

        public int AgendamentoId { get; set; }
    }
}