using AutoMapper;
using TimeZone.Business.Dtos.ContactDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles;

public class ContactMappingProfiles : Profile
{
    public ContactMappingProfiles()
    {
        CreateMap<Contact, ContactListItemDto>();
        CreateMap<ContactCreateDto, Contact>();
    }
}
