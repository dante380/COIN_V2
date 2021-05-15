using AutoMapper;
using FavoursShop.Core.Dto;
using FavoursShop.Core.Models;

namespace FavoursShop.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDto, Order>();
            CreateMap<FavourDto, Favour>();

            CreateMap<Favour, FavourDto>();
        }
    }
}
