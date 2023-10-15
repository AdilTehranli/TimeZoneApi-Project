using AutoMapper;
using TimeZone.Business.Dtos.BannerDto;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles;

public class BannerMappingProfiles : Profile
{
    public BannerMappingProfiles()
    {
        CreateMap<Banner, BannerListItemDto>();
        CreateMap<BannerCreateDto,Banner>();
        CreateMap<BannerUpdateDto,Banner>();
    }
}
