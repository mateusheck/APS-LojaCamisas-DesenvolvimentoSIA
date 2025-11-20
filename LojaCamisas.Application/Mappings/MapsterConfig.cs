using LojaCamisas.Application.ViewModels;
using LojaCamisas.Domain.Entities;
using Mapster;

namespace LojaCamisas.Application.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            // Camisa <-> CamisaCreateEditViewModel
            TypeAdapterConfig<Camisa, CamisaCreateEditViewModel>.NewConfig().TwoWays();

            // Camisa <-> CamisaViewModel
            TypeAdapterConfig<Camisa, CamisaViewModel>.NewConfig()
                .Map(dest => dest.MarcaNome, src => src.Marca.Nome);

            // Marca <-> MarcaViewModel (se usar)
            TypeAdapterConfig<Marca, MarcaViewModel>.NewConfig().TwoWays();
        }
    }
}
