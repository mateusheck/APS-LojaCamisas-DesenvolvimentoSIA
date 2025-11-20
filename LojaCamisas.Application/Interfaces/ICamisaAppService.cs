using LojaCamisas.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaCamisas.Application.Interfaces
{
    public interface ICamisaAppService
    {
        Task<IEnumerable<CamisaViewModel>> GetAllAsync();
        Task<CamisaCreateEditViewModel> GetByIdAsync(int id);
        Task<CamisaCreateEditViewModel> GetViewModelForCreation();
        Task<CamisaCreateEditViewModel> GetViewModelForUpdate(int id);
        Task CreateAsync(CamisaCreateEditViewModel model);
        Task UpdateAsync(CamisaCreateEditViewModel model);
        Task DeleteAsync(int id);
    }
}
