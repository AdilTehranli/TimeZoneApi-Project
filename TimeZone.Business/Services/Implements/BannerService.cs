using AutoMapper;
using BlogProject.Business.ExtensionServices.Interfaces;
using TimeZone.Business.Dtos.BannerDto;
using TimeZone.Business.Dtos.BannerDtos;
using TimeZone.Business.Dtos.BlogDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;
using TimeZone.DAL.Repositories.Implements;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class BannerService : IBannerService
{
    readonly IBannerRepository _bannerRepository;
    readonly IMapper _mapper;
    readonly IFileService _fileService;

    public BannerService(IBannerRepository bannerRepository, IFileService fileService, IMapper mapper)
    {
        _bannerRepository = bannerRepository;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task CreateAsnyc(BannerCreateDto createDto)
    {
        if (createDto == null)
        {
            throw new NullReferenceException("Data is null");
        }
        var mapper = _mapper.Map<Banner>(createDto);
        mapper.BannerImage = await _fileService.UploadAsync(createDto.BannerImage, Path.Combine("images"));
        if (mapper == null)
        {
            throw new NullReferenceException("Mapper is null");
        }

        await _bannerRepository.CreateAsync(mapper);
        await _bannerRepository.SaveAsync();
    }

    public async Task Delete(int id)
    {
        await _bannerRepository.DeleteAsync(id);
        await _bannerRepository.SaveAsync();
    }

    public async Task<IEnumerable<BannerListItemDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<BannerListItemDto>>(_bannerRepository.GetAll());

    }

    public async Task<BannerDetailDto> GetById(int id)
    {
        var entity = await _getBannerAsync(id);
        return _mapper.Map<BannerDetailDto>(entity);
    }

    public async Task UpdateAsnyc(int id, BannerUpdateDto updateDto)
    {
        if (id < 1)
        {
            throw new ArgumentException("Invalid ID. ID should be greater than or equal to 1.");
        }
        var entity = await _bannerRepository.FindByIdAsync(id);
        if (entity == null)
        {
            throw new NullReferenceException("not exist entity");
        }

        entity.BannerImage = await _fileService.UploadAsync(updateDto.BannerImage, Path.Combine("images"));
        entity.Title = updateDto.Title;
        entity.Price = updateDto.Price;

        await _bannerRepository.UpdateAsync(entity);
        await _bannerRepository.SaveAsync();
    }
    async Task<Banner> _getBannerAsync(int id)
    {
        if (id <= 0) throw new ArgumentException();
        var entity = await _bannerRepository.FindByIdAsync(id);
        if (entity == null) throw new NullReferenceException();
        return entity;
    }
}
