using AutoMapper;
using TimeZone.Business.Dtos.AboutDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles;

public class AboutMappingProfiles : Profile
{
    public AboutMappingProfiles()
    {
        CreateMap<About,AboutListItemDto>();
        CreateMap<AboutCreateDto,About>();
        CreateMap<AboutUpdateDto,About>();
    }
}
