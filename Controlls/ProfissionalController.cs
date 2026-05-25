using CLINICAINOVA.Data;
using CLINICAINOVA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLINICAINOVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfissionalController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR PROFISSIONAIS
        [HttpGet]
        public IActionResult Listar()
        {
            var profissionais = _context.Profissionais.ToList();

            return Ok(profissionais);
        }

        // CADASTRAR PROFISSIONAL
        [HttpPost]
        public IActionResult Criar(ProfissionalSaude profissional)
        {
            _context.Profissionais.Add(profissional);

            _context.SaveChanges();

            return Ok(profissional);
        }

        // AGENDA DO PROFISSIONAL
        [HttpGet("agenda/{id}")]
        public IActionResult Agenda(int id)
        {
            var agenda = _context.Agendamentos
                .Include(a => a.Paciente)
                .Include(a => a.Servico)
                .Where(a => a.ProfissionalId == id)
                .ToList();

            return Ok(agenda);
        }
    }
}