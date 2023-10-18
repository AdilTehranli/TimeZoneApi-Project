using TimeZone.Business.Dtos.BannerDto;
using TimeZone.Business.Dtos.ContactDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface IContactService
{
    Task<IEnumerable<ContactListItemDto>> GetAllAsync();
    Task CreateAsnyc(ContactCreateDto createDto);
    Task Delete(int id);
}
