using CLINICAINOVA.Data;
using CLINICAINOVA.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAINOVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.Servicos.ToList());
        }

        [HttpPost]
        public IActionResult Criar(Servico servico)
        {
            _context.Servicos.Add(servico);

            _context.SaveChanges();

            return Ok(servico);
        }
    }
}