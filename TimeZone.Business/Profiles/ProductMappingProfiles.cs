using AutoMapper;
using TimeZone.Business.Dtos.CategoryDtos;
using TimeZone.Business.Dtos.ProductDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles;
public class ProductMappingProfiles : Profile
{
    public ProductMappingProfiles()
    {
        CreateMap<Product, ProductDetailDto>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));

        CreateMap<Product, ProductListItemDto>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));

        CreateMap<ProductCreateDto, Product>();
        CreateMap<ProductUpdateDto, Product>();
    }
}



