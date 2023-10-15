using AutoMapper;
using TimeZone.Business.Dtos.WrapperDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles;

public class WrapperMappingProfiles : Profile
{
    public WrapperMappingProfiles()
    {
        CreateMap<WrapperCreateDto,Wrapper>();
        CreateMap<WrapperUpdateDto,Wrapper>();
        CreateMap<Wrapper,WrapperListItemDto>();
    }
}
