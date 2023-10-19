using AutoMapper;
using TimeZone.Business.Dtos.UserDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles;

public class UserMappingProfiles : Profile
{
    public UserMappingProfiles()
    {
        CreateMap<RegisterDto, AppUser>();
        CreateMap<AppUser, AuthorDto>();
    }
}
