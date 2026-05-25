namespace CLINICAINOVA.DTOs
{
    public class AgendamentoDTO
    {
        public DateTime DataHora { get; set; }

        public int PacienteId { get; set; }

        public int ProfissionalId { get; set; }

        public int ServicoId { get; set; }

        public bool RequerLibras { get; set; }
    }
}