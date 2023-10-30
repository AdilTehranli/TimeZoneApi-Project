using TimeZone.Business.Dtos.AboutDtos;
using TimeZone.Business.Dtos.BannerDto;
using TimeZone.Business.Dtos.BannerDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface IAboutService
{
    Task<IEnumerable<AboutListItemDto>> GetAllAsync();
    Task<AboutDetailDto> GetById(int id);

    Task CreateAsnyc(AboutCreateDto createDto);
    Task UpdateAsnyc(int id, AboutUpdateDto updateDto);
    Task Delete(int id);
}
