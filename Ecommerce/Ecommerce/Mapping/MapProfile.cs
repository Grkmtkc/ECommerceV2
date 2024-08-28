using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Addresses, AddressesDto>().ReverseMap();
            CreateMap<BaseEntity, BaseEntityDto>().ReverseMap();
            CreateMap<Products, ProductDto>().ReverseMap();
            CreateMap<Communications, CommunicationsDto>().ReverseMap();
            CreateMap<Customers, CustomerDto>().ReverseMap();
            CreateMap<Sales, SalesDto>().ReverseMap();
        }
    }
}
