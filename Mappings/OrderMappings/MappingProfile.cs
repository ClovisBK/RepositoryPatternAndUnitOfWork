using AutoMapper;
using RepositoryPattern.Dtos.OrderDtos;
using RepositoryPattern.Models;

namespace RepositoryPattern.Mappings.OrderMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();
        }
    }
}
