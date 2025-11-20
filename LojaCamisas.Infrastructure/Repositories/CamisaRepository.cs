using LojaCamisas.Domain.Entities;
using LojaCamisas.Domain.Interfaces;
using LojaCamisas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaCamisas.Infrastructure.Repositories
{
    public class CamisaRepository : Repository<Camisa>, ICamisaRepository
    {
        public CamisaRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Camisa>> GetAllAsync()
        {
            return await _dbSet
                .Include(c => c.Marca)
                .ToListAsync();
        }

        public override async Task<Camisa?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Marca)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Camisa>> BuscarAsync(string termo)
        {
            return await _dbSet
                .Include(c => c.Marca)
                .Where(c =>
                    c.Nome.Contains(termo) ||
                    c.Descricao.Contains(termo))
                .ToListAsync();
        }
    }
}
