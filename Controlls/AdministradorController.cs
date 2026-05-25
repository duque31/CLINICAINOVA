using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CLINICAINOVA.Data;

namespace CLINICAINOVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdministradorController(AppDbContext context)
        {
            _context = context;
        }

        // DASHBOARD ADMIN
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            var totalUsuarios = _context.Usuarios.Count();

            var totalPacientes = _context.Pacientes.Count();

            var totalProfissionais = _context.Profissionais.Count();

            var totalAgendamentos = _context.Agendamentos.Count();

            var totalProntuarios = _context.Prontuarios.Count();

            return Ok(new
            {
                totalUsuarios,
                totalPacientes,
                totalProfissionais,
                totalAgendamentos,
                totalProntuarios
            });
        }

        // LISTAR USUÁRIOS
        [HttpGet("usuarios")]
        public IActionResult Usuarios()
        {
            return Ok(_context.Usuarios.ToList());
        }

        // LISTAR AGENDAMENTOS
        [HttpGet("agendamentos")]
        public IActionResult Agendamentos()
        {
            var agendamentos = _context.Agendamentos
                .Include(a => a.Paciente)
                .Include(a => a.Profissional)
                .Include(a => a.Servico)
                .ToList();

            return Ok(agendamentos);
        }

        // RELATÓRIOS
        [HttpGet("relatorios")]
        public IActionResult Relatorios()
        {
            var consultasPendentes = _context.Agendamentos
                .Count(a => a.Status == "Pendente");

            var consultasConfirmadas = _context.Agendamentos
                .Count(a => a.Status == "Confirmado");

            var consultasCanceladas = _context.Agendamentos
                .Count(a => a.Status == "Cancelado");

            var consultasConcluidas = _context.Agendamentos
                .Count(a => a.Status == "Concluído");

            return Ok(new
            {
                consultasPendentes,
                consultasConfirmadas,
                consultasCanceladas,
                consultasConcluidas
            });
        }
    }
}