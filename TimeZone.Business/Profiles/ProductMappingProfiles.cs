using AutoMapper;
using TimeZone.Business.Dtos.CategoryDtos;
using TimeZone.Business.Dtos.ProductDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles;

public class ProductMappingProfiles : Profile
{
    public ProductMappingProfiles()
    {
        CreateMap<Product, ProductDetailDto>().ReverseMap();
        CreateMap<Product, ProductListItemDto>();
        CreateMap<ProductCreateDto, Product>();
        CreateMap<ProductUpdateDto, Product>();
    }
}


