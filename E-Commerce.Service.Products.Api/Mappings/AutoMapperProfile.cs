using AutoMapper;
using E_Commerce.Service.Products.Api.Models.Domain;
using E_Commerce.Service.Products.Api.Models.Dto;

namespace E_Commerce.Service.Products.Api.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<Product, ProductDto>().ReverseMap();
            
        
        }

    }
}
