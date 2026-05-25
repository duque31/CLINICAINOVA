namespace CLINICAINOVA.Models
{
    public class Paciente : Usuario
    {
        public List<Agendamento>? Agendamentos { get; set; }
    }
}