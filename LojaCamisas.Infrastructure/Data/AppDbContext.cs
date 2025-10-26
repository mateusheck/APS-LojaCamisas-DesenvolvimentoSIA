using LojaCamisas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaCamisas.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Camisa> Camisas { get; set; }
    }
}