using TimeZone.Business.Dtos.BannerDtos;
using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.CategoryDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryListItemDto>> GetAllAsync();
    Task<CategoryDetailDto> GetById(int id);

    Task CreateAsnyc(CategoryCreateDto createDto);
    Task UpdateAsnyc(int id, CategoryUpdateDto updateDto);
    Task Delete(int id);
}
