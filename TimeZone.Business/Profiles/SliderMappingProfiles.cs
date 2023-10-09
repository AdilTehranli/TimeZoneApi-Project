using AutoMapper;
using TimeZone.Business.Dtos.SliderDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles;

public class SliderMappingProfiles:Profile
{
    public SliderMappingProfiles() 
    {
        CreateMap<Slider,SliderListItemDto>();
        CreateMap<SliderCreateDto,Slider>();
        CreateMap<SliderUpdateDto,Slider>();
    }
}
