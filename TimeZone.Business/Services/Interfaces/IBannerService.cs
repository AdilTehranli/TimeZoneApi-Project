using TimeZone.Business.Dtos.BannerDto;
using TimeZone.Business.Dtos.BrandDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface IBannerService
{
    Task<IEnumerable<BannerListItemDto>> GetAllAsync();
    Task CreateAsnyc(BannerCreateDto createDto);
    Task UpdateAsnyc(int id, BannerUpdateDto updateDto);
    Task Delete(int id);
}
