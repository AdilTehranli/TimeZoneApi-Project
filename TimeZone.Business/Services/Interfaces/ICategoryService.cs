using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.CategoryDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryListItemDto>> GetAllAsync();
    Task CreateAsnyc(CategoryCreateDto createDto);
    Task UpdateAsnyc(int id, CategoryUpdateDto updateDto);
    Task Delete(int id);
}
