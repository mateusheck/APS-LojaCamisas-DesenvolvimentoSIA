using AutoMapper;
using LojaCamisas.Domain.Entities;
using LojaCamisas.Application.ViewModels;

namespace LojaCamisas.Application.Mappings
{
    public class CamisaProfile : Profile
    {
        public CamisaProfile()
        {
            CreateMap<Camisa, CamisaViewModel>().ReverseMap();
            CreateMap<Camisa, CamisaCreateEditViewModel>().ReverseMap();
        }
    }
}
