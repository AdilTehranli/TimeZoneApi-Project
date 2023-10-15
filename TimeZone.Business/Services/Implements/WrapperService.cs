using AutoMapper;
using BlogProject.Business.ExtensionServices.Implements;
using BlogProject.Business.ExtensionServices.Interfaces;
using TimeZone.Business.Dtos.SliderDtos;
using TimeZone.Business.Dtos.WrapperDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class WrapperService : IWrapperService
{
    readonly IWrapperRepository _wrapperRepository;
    readonly IMapper _mapper;
    public WrapperService(IWrapperRepository wrapperRepository, IMapper mapper)
    {
        _wrapperRepository = wrapperRepository;
        _mapper = mapper;
    }

    public async Task CreateAsnyc(WrapperCreateDto createDto)
    {
        if (createDto == null)
        {
            throw new NullReferenceException("Data is null");
        }
        var mapper = _mapper.Map<Wrapper>(createDto);
        if (mapper == null)
        {
            throw new NullReferenceException("Mapper is null");
        }
        await _wrapperRepository.CreateAsync(mapper);
        await _wrapperRepository.SaveAsync();
    }

    public async Task Delete(int id)
    {
        await _wrapperRepository.DeleteAsync(id);
        await _wrapperRepository.SaveAsync();
    }

    public async Task<IEnumerable<WrapperListItemDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<WrapperListItemDto>>(_wrapperRepository.GetAll());
    }

    public async Task UpdateAsnyc(int id, WrapperUpdateDto updateDto)
    {

        if (id < 1)
        {
            throw new ArgumentException("Invalid ID. ID should be greater than or equal to 1.");
        }
        var entity = await _wrapperRepository.FindByIdAsync(id);
        if (entity == null)
        {
            throw new NullReferenceException("not exist entity");
        }
    
        entity.Icon = updateDto.Icon;
        entity.Title = updateDto.Title;
        entity.Description = updateDto.Description;

        await _wrapperRepository.UpdateAsync(entity);
        await _wrapperRepository.SaveAsync();
    }
}
