using CLINICAINOVA.Data;
using CLINICAINOVA.DTOs;
using CLINICAINOVA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLINICAINOVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProntuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProntuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var prontuarios = _context.Prontuarios
                .Include(p => p.Agendamento)
                .ToList();

            return Ok(prontuarios);
        }

        [HttpPost]
        public IActionResult Criar(ProntuarioDTO dto)
        {
            var prontuario = new Prontuario
            {
                EvolucaoClinica = dto.EvolucaoClinica,
                Prescricao = dto.Prescricao,
                Exames = dto.Exames,
                AgendamentoId = dto.AgendamentoId
            };

            _context.Prontuarios.Add(prontuario);

            _context.SaveChanges();

            return Ok(prontuario);
        }

        // PRONTUÁRIOS DO PACIENTE
        [HttpGet("paciente/{id}")]
        public IActionResult PorPaciente(int id)
        {
            var prontuarios = _context.Prontuarios
                .Include(p => p.Agendamento)
                    .ThenInclude(a => a.Servico)
                .Include(p => p.Agendamento)
                    .ThenInclude(a => a.Profissional)
                .Where(p => p.Agendamento.PacienteId == id)
                .ToList();

            return Ok(prontuarios);
        }
    }
}