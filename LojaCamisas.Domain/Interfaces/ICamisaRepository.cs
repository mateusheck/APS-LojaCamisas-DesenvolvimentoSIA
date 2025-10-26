using LojaCamisas.Domain.Entities;

namespace LojaCamisas.Domain.Interfaces
{
    public interface ICamisaRepository
    {
        Task<Camisa> GetByIdAsync(int id);
        Task<IEnumerable<Camisa>> GetAllAsync();
        Task AddAsync(Camisa camisa);
        Task UpdateAsync(Camisa camisa);
        Task DeleteAsync(int id);
    }
}