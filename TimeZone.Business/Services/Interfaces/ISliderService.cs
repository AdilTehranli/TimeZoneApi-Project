using TimeZone.Business.Dtos.SliderDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface ISliderService
{
    Task<IEnumerable<SliderListItemDto>> GetAllAsync();
    Task CreateAsnyc(SliderCreateDto createDto);
    Task UpdateAsnyc(int id,SliderUpdateDto updateDto);
    Task Delete(int id);
}
