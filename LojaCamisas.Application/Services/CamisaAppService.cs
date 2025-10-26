using LojaCamisas.Application.Interfaces;
using LojaCamisas.Application.ViewModels;
using LojaCamisas.Domain.Entities;
using LojaCamisas.Domain.Interfaces;

namespace LojaCamisas.Application.Services
{
    public class CamisaAppService : ICamisaAppService
    {
        private readonly ICamisaRepository _camisaRepository;

        public CamisaAppService(ICamisaRepository camisaRepository)
        {
            _camisaRepository = camisaRepository;
        }

        public async Task AddAsync(CamisaViewModel camisaViewModel)
        {
            var camisa = new Camisa
            {
                Time = camisaViewModel.Time,
                Temporada = camisaViewModel.Temporada,
                Preco = camisaViewModel.Preco,
                QuantidadeEstoque = camisaViewModel.QuantidadeEstoque
            };
            await _camisaRepository.AddAsync(camisa);
        }

        public async Task DeleteAsync(int id)
        {
            await _camisaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CamisaViewModel>> GetAllAsync()
        {
            var camisas = await _camisaRepository.GetAllAsync();
            return camisas.Select(c => new CamisaViewModel
            {
                Id = c.Id,
                Time = c.Time,
                Temporada = c.Temporada,
                Preco = c.Preco,
                QuantidadeEstoque = c.QuantidadeEstoque
            });
        }

        public async Task<CamisaViewModel> GetByIdAsync(int id)
        {
            var camisa = await _camisaRepository.GetByIdAsync(id);
            if (camisa == null) return null;

            return new CamisaViewModel
            {
                Id = camisa.Id,
                Time = camisa.Time,
                Temporada = camisa.Temporada,
                Preco = camisa.Preco,
                QuantidadeEstoque = camisa.QuantidadeEstoque
            };
        }

        public async Task UpdateAsync(CamisaViewModel camisaViewModel)
        {
            var camisa = await _camisaRepository.GetByIdAsync(camisaViewModel.Id);
            if (camisa != null)
            {
                camisa.Time = camisaViewModel.Time;
                camisa.Temporada = camisaViewModel.Temporada;
                camisa.Preco = camisaViewModel.Preco;
                camisa.QuantidadeEstoque = camisaViewModel.QuantidadeEstoque;

                await _camisaRepository.UpdateAsync(camisa);
            }
        }
    }
}