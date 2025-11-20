using LojaCamisas.Application.Interfaces;
using LojaCamisas.Application.ViewModels;
using LojaCamisas.Domain.Entities;
using LojaCamisas.Domain.Interfaces;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaCamisas.Application.Services
{
    public class MarcaAppService : IMarcaAppService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaAppService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<IEnumerable<MarcaViewModel>> GetAllAsync()
        {
            var marcas = await _marcaRepository.GetAllAsync();
            return marcas.Adapt<IEnumerable<MarcaViewModel>>();
        }

        public async Task<MarcaViewModel?> GetByIdAsync(int id)
        {
            var marca = await _marcaRepository.GetByIdAsync(id);
            return marca?.Adapt<MarcaViewModel>();
        }

        public async Task<MarcaViewModel> CreateAsync(MarcaViewModel model)
        {
            var marca = model.Adapt<Marca>();
            await _marcaRepository.AddAsync(marca);
            return marca.Adapt<MarcaViewModel>();
        }

        public async Task UpdateAsync(MarcaViewModel model)
        {
            var marca = model.Adapt<Marca>();
            await _marcaRepository.UpdateAsync(marca);
        }

        public async Task DeleteAsync(int id)
        {
            await _marcaRepository.DeleteAsync(id);
        }
    }
}
