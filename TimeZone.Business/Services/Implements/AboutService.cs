using AutoMapper;
using TimeZone.Business.Dtos.AboutDtos;
using TimeZone.Business.Dtos.BannerDtos;
using TimeZone.Business.Dtos.CategoryDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;
using TimeZone.DAL.Repositories.Implements;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class AboutService : IAboutService
{
    readonly IAboutRepository _aboutRepository;
    readonly IMapper _mapper;

    public AboutService(IAboutRepository aboutRepository, IMapper mapper)
    {
        _aboutRepository = aboutRepository;
        _mapper = mapper;
    }

    public async Task CreateAsnyc(AboutCreateDto createDto)
    {
        if (createDto == null)
        {
            throw new NullReferenceException("Data is null");
        }
        var mapper = _mapper.Map<About>(createDto);
        if (mapper == null)
        {
            throw new NullReferenceException("Mapper is null");
        }
        await _aboutRepository.CreateAsync(mapper);
        await _aboutRepository.SaveAsync();
    }

    public async Task Delete(int id)
    {
        await _aboutRepository.DeleteAsync(id);
        await _aboutRepository.SaveAsync();
    }

    public async Task<IEnumerable<AboutListItemDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<AboutListItemDto>>(_aboutRepository.GetAll());

    }

    public async Task<AboutDetailDto> GetById(int id)
    {
        var entity = await _getAboutAsync(id);
        return _mapper.Map<AboutDetailDto>(entity);
    }

    public async Task UpdateAsnyc(int id, AboutUpdateDto updateDto)
    {
        if (id < 1)
        {
            throw new ArgumentException("Invalid ID. ID should be greater than or equal to 1.");
        }
        var entity = await _aboutRepository.FindByIdAsync(id);
        if (entity == null)
        {
            throw new NullReferenceException("not exist entity");
        }

        entity.Title = updateDto.Title;
        entity.Description = updateDto.Description;

        await _aboutRepository.UpdateAsync(entity);
        await _aboutRepository.SaveAsync();
    }
    async Task<About> _getAboutAsync(int id)
    {
        if (id <= 0) throw new ArgumentException();
        var entity = await _aboutRepository.FindByIdAsync(id);
        if (entity == null) throw new NullReferenceException();
        return entity;
    }
}
