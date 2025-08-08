using Microsoft.EntityFrameworkCore;
using LoginAPI.Models;

namespace LoginAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Identificacion).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Password).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
                entity.HasIndex(e => e.Identificacion).IsUnique();
            });
        }
    }
}
