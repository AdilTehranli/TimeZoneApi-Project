using TimeZone.Business.Dtos.BannerDto;
using TimeZone.Business.Dtos.ContactDtos;
using TimeZone.Business.Dtos.ProductDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface IContactService
{
    Task<IEnumerable<ContactListItemDto>> GetAllAsync();
    Task<ContactDetailDto> GetById(int id);
    Task CreateAsnyc(ContactCreateDto createDto);
    Task Delete(int id);
}
