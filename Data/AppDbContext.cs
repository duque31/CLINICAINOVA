using CLINICAINOVA.Models;
using Microsoft.EntityFrameworkCore;

namespace CLINICAINOVA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<ProfissionalSaude> Profissionais { get; set; }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Servico> Servicos { get; set; }

        public DbSet<Agendamento> Agendamentos { get; set; }

        public DbSet<Prontuario> Prontuarios { get; set; }
    }
}