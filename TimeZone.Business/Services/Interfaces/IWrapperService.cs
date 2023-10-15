using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.WrapperDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface IWrapperService
{
    Task<IEnumerable<WrapperListItemDto>> GetAllAsync();
    Task CreateAsnyc(WrapperCreateDto createDto);
    Task UpdateAsnyc(int id, WrapperUpdateDto updateDto);
    Task Delete(int id);
}
