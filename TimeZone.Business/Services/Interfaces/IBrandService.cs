using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.SliderDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface IBrandService
{
    Task<IEnumerable<BrandListItemDto>> GetAllAsync();
    Task CreateAsnyc(BrandCreateDto createDto);
    Task UpdateAsnyc(int id, BrandUpdateDto updateDto);
    Task Delete(int id);
}
