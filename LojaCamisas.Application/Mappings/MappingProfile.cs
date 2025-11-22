using AutoMapper;
using LojaCamisas.Application.ViewModels;
using LojaCamisas.Domain.Entities;

namespace LojaCamisas.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Camisa, CamisaViewModel>().ReverseMap();

            CreateMap<Camisa, CamisaCreateEditViewModel>()
                .ForMember(dest => dest.Marcas, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Marca, opt => opt.Ignore());

            CreateMap<Marca, MarcaViewModel>().ReverseMap();
        }
    }
}
