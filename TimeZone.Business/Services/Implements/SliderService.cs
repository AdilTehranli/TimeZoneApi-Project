using TimeZone.Business.Dtos.SliderDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class SliderService : ISliderService
{
    readonly ISliderRepository _sliderRepo;
    public SliderService(ISliderRepository sliderRepo)
    {
        _sliderRepo = sliderRepo;
    }

    public Task CreateAsnyc(SliderCreateDto createDto)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
        await _sliderRepo.DeleteAsync(id);
    }

    public Task<IEnumerable<SliderListItemDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsnyc(int id, SliderUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }
}
