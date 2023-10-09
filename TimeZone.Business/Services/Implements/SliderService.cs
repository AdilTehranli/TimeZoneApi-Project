using AutoMapper;
using BlogProject.Business.ExtensionServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using TimeZone.Business.Dtos.SliderDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class SliderService : ISliderService
{
    readonly IFileService _fileservice;
    readonly ISliderRepository _sliderRepo;
    readonly IMapper _mapper;
    public SliderService(ISliderRepository sliderRepo, IMapper mapper, IFileService fileservice)
    {
        _sliderRepo = sliderRepo;
        _mapper = mapper;
        _fileservice = fileservice;
    }

    public async Task CreateAsnyc(SliderCreateDto createDto)
    {
      if(createDto == null)
        {
            throw new NullReferenceException("Data is null");
        }
        var mapper = _mapper.Map<Slider>(createDto);
        mapper.SliderImage = await _fileservice.UploadAsync(createDto.SliderImage, Path.Combine("images", "img"));
        if(mapper == null)
        {
            throw new NullReferenceException("Mapper is null");
        }
        await _sliderRepo.CreateAsync(mapper);
        await _sliderRepo.SaveAsync();
    }

    public async Task Delete(int id)
    {
        await _sliderRepo.DeleteAsync(id);
        await _sliderRepo.SaveAsync();
    }

    public async Task<IEnumerable<SliderListItemDto>> GetAllAsync()
    {
   
        return _mapper.Map<IEnumerable<SliderListItemDto>>(_sliderRepo.GetAll());
        
    }

    public Task UpdateAsnyc(int id, SliderUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }
}
