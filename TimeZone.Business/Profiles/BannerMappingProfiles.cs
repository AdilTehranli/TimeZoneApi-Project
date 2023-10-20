using AutoMapper;
using TimeZone.Business.Dtos.BannerDto;
using TimeZone.Business.Dtos.BannerDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles;

public class BannerMappingProfiles : Profile
{
    public BannerMappingProfiles()
    {
        CreateMap<Banner, BannerListItemDto>();
        CreateMap<Banner, BannerDetailDto>();
        CreateMap<BannerCreateDto,Banner>();
        CreateMap<BannerUpdateDto,Banner>();
    }
}
