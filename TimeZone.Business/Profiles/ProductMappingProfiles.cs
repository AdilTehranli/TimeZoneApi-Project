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
        CreateMap<Product, ProductListItemDto>()
.ForMember(dest => dest.Category, opt => opt.MapFrom(p => p.CategoryId != null ? p.CategoryId.ToString() : null))
.ForMember(dest => dest.Brand, opt => opt.MapFrom(p => p.BrandId != null ? p.BrandId.ToString() : null));

        CreateMap<ProductCreateDto, Product>();
        CreateMap<ProductUpdateDto, Product>();
    }
}


