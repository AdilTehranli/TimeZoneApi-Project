using AutoMapper;
using BlogProject.Business.ExtensionServices.Implements;
using BlogProject.Business.ExtensionServices.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using TimeZone.Business.Dtos.BannerDtos;
using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.SliderDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;
using TimeZone.DAL.Repositories.Implements;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class BrandService : IBrandService
{
    readonly IBrandRepository _brandRepository;
    readonly IMapper _mapper;

    public BrandService(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task CreateAsnyc(BrandCreateDto createDto)
    {
        if (createDto == null)
        {
            throw new NullReferenceException("Data is null");
        }
        var mapper = _mapper.Map<Brand>(createDto);
        if (mapper == null)
        {
            throw new NullReferenceException("Mapper is null");
        }
        await _brandRepository.CreateAsync(mapper);
        await _brandRepository.SaveAsync();
    }

    public async Task Delete(int id)
    {
        await _brandRepository.DeleteAsync(id);
        await _brandRepository.SaveAsync();
    }

    public async Task<IEnumerable<BrandListItemDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<BrandListItemDto>>(_brandRepository.GetAll());
    }

    public async Task<BrandDetailDto> GetById(int id)
    {
        var entity = await _getBrandAsync(id);
        return _mapper.Map<BrandDetailDto>(entity);
    }

    public async Task UpdateAsnyc(int id, BrandUpdateDto updateDto)
    {
        if (id < 1)
        {
            throw new ArgumentException("Invalid ID. ID should be greater than or equal to 1.");
        }
        var entity = await _brandRepository.FindByIdAsync(id);
        if (entity == null)
        {
            throw new NullReferenceException("not exist entity");
        }

        entity.Name = updateDto.Name;

        await _brandRepository.UpdateAsync(entity);
        await _brandRepository.SaveAsync();
    }
    async Task<Brand> _getBrandAsync(int id)
    {
        if (id <= 0) throw new ArgumentException();
        var entity = await _brandRepository.FindByIdAsync(id);
        if (entity == null) throw new NullReferenceException();
        return entity;
    }
}
