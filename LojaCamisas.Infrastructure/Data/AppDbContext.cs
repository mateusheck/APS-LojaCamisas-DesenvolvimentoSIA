using LojaCamisas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaCamisas.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Camisa> Camisas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            builder.Entity<Marca>().HasData(
                new { Id = 1, Nome = "Adidas" },
                new { Id = 2, Nome = "Nike" },
                new { Id = 3, Nome = "Puma" },
                new { Id = 4, Nome = "Kappa" }
            );
        }
    }
}
