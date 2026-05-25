using Microsoft.AspNetCore.Mvc;
using CLINICAINOVA.Data;
using CLINICAINOVA.DTOs;
using CLINICAINOVA.Models;

namespace CLINICAINOVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // CADASTRO
        [HttpPost("cadastro")]
        public IActionResult Cadastro(CadastroDTO dto)
        {
            var usuarioExistente = _context.Usuarios
                .FirstOrDefault(u => u.Email == dto.Email);

            if (usuarioExistente != null)
            {
                return BadRequest("Email já cadastrado");
            }

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
                Perfil = dto.Perfil,
                Cpf = dto.Cpf,
                Telefone = dto.Telefone,
                DataNascimento = dto.DataNascimento
            };

            _context.Usuarios.Add(usuario);

            _context.SaveChanges();

            return Ok(usuario);
        }

        // LOGIN
        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u =>
                    u.Email == dto.Email &&
                    u.Senha == dto.Senha);

            if (usuario == null)
            {
                return Unauthorized("Email ou senha inválidos");
            }

            return Ok(usuario);
        }
    }
}