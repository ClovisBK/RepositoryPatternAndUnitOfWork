using AutoMapper;
using RepositoryPattern.Dtos.CustomerDtos;
using RepositoryPattern.Models;

namespace RepositoryPattern.Mappings.CustomerMappings
{
    public class  MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
        }
    }
}
