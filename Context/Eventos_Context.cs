using EventPlus_.Domains;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Context
{

    public class Eventos_Context : DbContext
    {
        public Eventos_Context()
        {
        }

        public Eventos_Context(DbContextOptions<Eventos_Context> options) : base(options) 
        {
        }

        public DbSet<ComentarioEvento> ComentarioEventos { get; set; }
        public DbSet<Eventos> Evento { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
        public DbSet<TipoEvento> TipoEventos { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = DESKTOP-ALUUT85 \\SQLEXPRESS; Database = EventPlus; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;");
            }
        }

    }  
}
