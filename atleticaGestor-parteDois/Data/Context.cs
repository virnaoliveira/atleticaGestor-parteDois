using atleticaGestor_parteDois.Models;
using Microsoft.EntityFrameworkCore;

namespace atleticaGestor_parteDois.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Time> Time { get; set; }
        public DbSet<Atleta> Atleta { get; set; }
        public DbSet<Associacaomembrotime> Associacaomembrotime { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("atleticagestor");
            modelBuilder.Entity<Time>().HasKey(t => t.idtime);
            modelBuilder.Entity<Atleta>().HasKey(a => a.membro_matricula);
            modelBuilder.Entity<Associacaomembrotime>().HasKey(am => am.membro_matricula);
            base.OnModelCreating(modelBuilder);
        }
    }
}
