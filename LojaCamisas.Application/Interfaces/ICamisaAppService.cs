using LojaCamisas.Application.ViewModels;

namespace LojaCamisas.Application.Interfaces
{
    public interface ICamisaAppService
    {
        Task<CamisaViewModel> GetByIdAsync(int id);
        Task<IEnumerable<CamisaViewModel>> GetAllAsync();
        Task AddAsync(CamisaViewModel camisaViewModel);
        Task UpdateAsync(CamisaViewModel camisaViewModel);
        Task DeleteAsync(int id);
    }
}