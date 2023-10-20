using AutoMapper;
using TimeZone.Business.Dtos.BannerDto;
using TimeZone.Business.Dtos.BlogDtos;
using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.ContactDtos;
using TimeZone.Business.Dtos.ProductDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;
using TimeZone.DAL.Repositories.Implements;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.Business.Services.Implements;
 
public class ContactService : IContactService
{
    readonly IContactRepository _contactRepository;
    readonly IMapper _mapper;
    public ContactService(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public async Task CreateAsnyc(ContactCreateDto createDto)
    {
        if (createDto == null)
        {
            throw new NullReferenceException("Data is null");
        }
        var mapper = _mapper.Map<Contact>(createDto);
        if (mapper == null)
        {
            throw new NullReferenceException("Mapper is null");
        }
        await _contactRepository.CreateAsync(mapper);
        await _contactRepository.SaveAsync();
    }

    public async Task Delete(int id)
    {
        await _contactRepository.DeleteAsync(id);
        await _contactRepository.SaveAsync();
    }

    public async Task<IEnumerable<ContactListItemDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ContactListItemDto>>(_contactRepository.GetAll());
    }

    public async Task<ContactDetailDto> GetById(int id)
    {
        var entity = await _getContactAsync(id);
        return _mapper.Map<ContactDetailDto>(entity);
    }
    async Task<Contact> _getContactAsync(int id)
    {
        if (id <= 0) throw new ArgumentException();
        var entity = await _contactRepository.FindByIdAsync(id);
        if (entity == null) throw new NullReferenceException();
        return entity;
    }
}
