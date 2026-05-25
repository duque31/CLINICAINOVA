using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CLINICAINOVA.Data;

namespace CLINICAINOVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PacienteController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR PACIENTES
        [HttpGet]
        public IActionResult Listar()
        {
            var pacientes = _context.Pacientes.ToList();

            return Ok(pacientes);
        }

        // BUSCAR PACIENTE POR ID
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            var paciente = _context.Pacientes.Find(id);

            if (paciente == null)
            {
                return NotFound("Paciente não encontrado");
            }

            return Ok(paciente);
        }

        // HISTÓRICO DO PACIENTE
        [HttpGet("historico/{id}")]
        public IActionResult Historico(int id)
        {
            var historico = _context.Agendamentos
                .Include(a => a.Servico)
                .Include(a => a.Profissional)
                .Where(a => a.PacienteId == id)
                .ToList();

            return Ok(historico);
        }
    }
}