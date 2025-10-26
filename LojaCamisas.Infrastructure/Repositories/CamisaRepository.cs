using LojaCamisas.Domain.Entities;
using LojaCamisas.Domain.Interfaces;
using LojaCamisas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LojaCamisas.Infrastructure.Repositories
{
    public class CamisaRepository : ICamisaRepository
    {
        private readonly AppDbContext _context;

        public CamisaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Camisa camisa)
        {
            await _context.Camisas.AddAsync(camisa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var camisa = await _context.Camisas.FindAsync(id);
            if (camisa != null)
            {
                _context.Camisas.Remove(camisa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Camisa>> GetAllAsync()
        {
            return await _context.Camisas.ToListAsync();
        }

        public async Task<Camisa> GetByIdAsync(int id)
        {
            return await _context.Camisas.FindAsync(id);
        }

        public async Task UpdateAsync(Camisa camisa)
        {
            _context.Entry(camisa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}