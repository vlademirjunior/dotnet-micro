using AutoMapper;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();// mapeamento bi-direcional
        CreateMap<Product, ProductDTO>().ReverseMap();// mapeamento bi-direcional
    }
}
