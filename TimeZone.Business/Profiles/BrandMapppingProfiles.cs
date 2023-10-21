using AutoMapper;
using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles;

public class BrandMapppingProfiles : Profile
{
    public BrandMapppingProfiles()
    {
        CreateMap<BrandCreateDto, Brand>();
        CreateMap<BrandUpdateDto, Brand>();
        CreateMap<Brand, BrandListItemDto>();
        CreateMap<Brand, BrandDetailDto>();
    }
}
