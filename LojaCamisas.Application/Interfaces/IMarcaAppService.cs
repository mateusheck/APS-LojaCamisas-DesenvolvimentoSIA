using LojaCamisas.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaCamisas.Application.Interfaces
{
    public interface IMarcaAppService
    {
        Task<IEnumerable<MarcaViewModel>> GetAllAsync();
        Task<MarcaViewModel?> GetByIdAsync(int id);
        Task<MarcaViewModel> CreateAsync(MarcaViewModel model);
        Task UpdateAsync(MarcaViewModel model);
        Task DeleteAsync(int id);
    }
}