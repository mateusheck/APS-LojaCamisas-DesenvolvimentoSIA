using LojaCamisas.Domain.Entities;
using LojaCamisas.Domain.Interfaces;
using LojaCamisas.Infrastructure.Data;

namespace LojaCamisas.Infrastructure.Repositories
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        public MarcaRepository(AppDbContext context) : base(context)
        {
        }
    }
}