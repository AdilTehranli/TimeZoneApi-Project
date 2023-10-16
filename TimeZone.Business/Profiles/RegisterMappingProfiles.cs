using AutoMapper;
using TimeZone.Business.Dtos.UserDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles;

public class RegisterMappingProfiles : Profile
{
    public RegisterMappingProfiles()
    {
        CreateMap<RegisterDto, AppUser>();
    }
}
