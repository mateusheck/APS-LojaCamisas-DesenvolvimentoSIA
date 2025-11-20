using AutoMapper;
using LojaCamisas.Application.ViewModels;
using LojaCamisas.Domain.Entities;

namespace LojaCamisas.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Camisa <-> CamisaViewModel (lista e detalhes)
            CreateMap<Camisa, CamisaViewModel>().ReverseMap();

            // Camisa <-> CamisaCreateEditViewModel (formulário)
            CreateMap<Camisa, CamisaCreateEditViewModel>()
                .ForMember(dest => dest.Marcas, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Marca, opt => opt.Ignore());

            // Marca <-> MarcaViewModel
            CreateMap<Marca, MarcaViewModel>().ReverseMap();
        }
    }
}
