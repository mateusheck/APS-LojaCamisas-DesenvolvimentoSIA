using AutoMapper;
using LojaCamisas.Application.Interfaces;
using LojaCamisas.Application.ViewModels;
using LojaCamisas.Domain.Entities;
using LojaCamisas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaCamisas.Application.Services
{
    public class CamisaAppService : ICamisaAppService
    {
        private readonly ICamisaRepository _camisaRepository;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMapper _mapper;

        public CamisaAppService(
            ICamisaRepository camisaRepository,
            IMarcaRepository marcaRepository,
            IMapper mapper)
        {
            _camisaRepository = camisaRepository;
            _marcaRepository = marcaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CamisaViewModel>> GetAllAsync()
        {
            var camisas = await _camisaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CamisaViewModel>>(camisas);
        }

        public async Task<CamisaCreateEditViewModel> GetByIdAsync(int id)
        {
            var camisa = await _camisaRepository.GetByIdAsync(id);
            var vm = _mapper.Map<CamisaCreateEditViewModel>(camisa);

            await CarregarMarcas(vm);

            return vm;
        }

        public async Task<CamisaCreateEditViewModel> GetViewModelForCreation()
        {
            var vm = new CamisaCreateEditViewModel();
            await CarregarMarcas(vm);
            return vm;
        }

        public async Task<CamisaCreateEditViewModel> GetViewModelForUpdate(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task CreateAsync(CamisaCreateEditViewModel model)
        {
            var camisa = _mapper.Map<Camisa>(model);
            await _camisaRepository.AddAsync(camisa);
        }

        public async Task UpdateAsync(CamisaCreateEditViewModel model)
        {
            var camisa = _mapper.Map<Camisa>(model);
            await _camisaRepository.UpdateAsync(camisa);
        }

        public async Task DeleteAsync(int id)
        {
            await _camisaRepository.DeleteAsync(id);
        }

        private async Task CarregarMarcas(CamisaCreateEditViewModel vm)
        {
            var marcas = await _marcaRepository.GetAllAsync();

            vm.Marcas = marcas.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Nome
            }).ToList();
        }
    }
}
