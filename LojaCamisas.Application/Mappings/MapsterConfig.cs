using LojaCamisas.Application.ViewModels;
using LojaCamisas.Domain.Entities;
using Mapster;

namespace LojaCamisas.Application.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Camisa, CamisaCreateEditViewModel>.NewConfig().TwoWays();

            TypeAdapterConfig<Camisa, CamisaViewModel>.NewConfig()
                .Map(dest => dest.MarcaNome, src => src.Marca.Nome);

            TypeAdapterConfig<Marca, MarcaViewModel>.NewConfig().TwoWays();
        }
    }
}
