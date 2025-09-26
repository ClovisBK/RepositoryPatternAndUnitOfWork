using AutoMapper;
using RepositoryPattern.Dtos.ProductDtos;
using RepositoryPattern.Models;

namespace RepositoryPattern.Mappings.ProductMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
