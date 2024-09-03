using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Addresses, AddressDto>().ReverseMap();
            CreateMap<BaseEntity, BaseEntityDto>().ReverseMap();
            CreateMap<Products, ProductDto>().ReverseMap();
            CreateMap<Communications, CommunicationDto>().ReverseMap();
            CreateMap<Customers, CustomerDto>().ReverseMap();
            CreateMap<Sales, SaleDto>().ReverseMap();

            CreateMap<Customers, CustomerDto>()
           .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
           .ForMember(dest => dest.Communications, opt => opt.MapFrom(src => src.Communications))
           .ForMember(dest => dest.Sales, opt => opt.MapFrom(src => src.Sales))
           .ReverseMap();
        }
    }
}
