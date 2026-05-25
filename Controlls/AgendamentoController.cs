using CLINICAINOVA.Data;
using CLINICAINOVA.DTOs;
using CLINICAINOVA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLINICAINOVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var agendamentos = _context.Agendamentos
                .Include(a => a.Paciente)
                .Include(a => a.Profissional)
                .Include(a => a.Servico)
                .ToList();

            return Ok(agendamentos);
        }

        [HttpPost]
        public IActionResult Criar(AgendamentoDTO dto)
        {
            if (!_context.Usuarios.Any(u => u.Id == dto.ProfissionalId))
            {
                return NotFound($"Profissional com Id {dto.ProfissionalId} não encontrado.");
            }

            var agendamento = new Agendamento
            {
                DataHora = dto.DataHora,
                PacienteId = dto.PacienteId,
                ProfissionalId = dto.ProfissionalId,
                ServicoId = dto.ServicoId,
                RequerLibras = dto.RequerLibras,
                Status = "Pendente"
            };

            _context.Agendamentos.Add(agendamento);

            _context.SaveChanges();

            return Ok(agendamento);
        }

        // CONFIRMAR CONSULTA
        [HttpPut("confirmar/{id}")]
        public IActionResult Confirmar(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);

            if (agendamento == null)
            {
                return NotFound("Agendamento não encontrado");
            }

            agendamento.Status = "Confirmado";

            _context.SaveChanges();

            return Ok(agendamento);
        }

        // CANCELAR CONSULTA
        [HttpPut("cancelar/{id}")]
        public IActionResult CancelarConsulta(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);

            if (agendamento == null)
            {
                return NotFound("Agendamento não encontrado");
            }

            agendamento.Status = "Cancelado";

            _context.SaveChanges();

            return Ok(agendamento);
        }

        // FINALIZAR CONSULTA
        [HttpPut("finalizar/{id}")]
        public IActionResult Finalizar(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);

            if (agendamento == null)
            {
                return NotFound("Agendamento não encontrado");
            }

            agendamento.Status = "Concluído";

            _context.SaveChanges();

            return Ok(agendamento);
        }

        // DELETE ANTIGO
        [HttpDelete("{id}")]
        public IActionResult Cancelar(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            _context.Agendamentos.Remove(agendamento);

            _context.SaveChanges();

            return Ok("Agendamento cancelado");
        }
    }
}