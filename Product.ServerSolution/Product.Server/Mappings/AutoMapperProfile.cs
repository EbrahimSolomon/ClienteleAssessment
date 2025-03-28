using AutoMapper;
using Product.Server.Models;
using Product.Server.DTOs;

namespace Product.Server.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product.Server.Models.Product, ProductDto>().ReverseMap();
        }
    }
}
