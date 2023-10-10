using AutoMapper;
using BlogProject.Business.ExtensionServices.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.IO;
using TimeZone.Business.Dtos.SliderDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;
using TimeZone.DAL.Contexts;
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
        mapper.SliderImage = await _fileservice.UploadAsync(createDto.SliderImage, Path.Combine("images"));
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
   
        return _mapper.Map<IEnumerable<SliderListItemDto>>( _sliderRepo.GetAll());
        
    }

    public async Task UpdateAsnyc(int id, SliderUpdateDto updateDto)
    {
        if (id < 1)
        {
            throw new ArgumentException("Invalid ID. ID should be greater than or equal to 1.");
        }
        var entity = await _sliderRepo.FindByIdAsync(id);
        if (entity == null)
        {
            throw new NullReferenceException("not exist entity");
        }

        entity.SliderImage = await _fileservice.UploadAsync(updateDto.SliderImage, Path.Combine("images"));
        entity.Title = updateDto.Title;
       entity.Description = updateDto.Description;
       
        await _sliderRepo.UpdateAsync(entity);
        await _sliderRepo.SaveAsync();
    }


}
