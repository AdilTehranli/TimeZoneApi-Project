using TimeZone.Business.Dtos.BlogDtos;
using TimeZone.Business.Dtos.ProductDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface IBlogService
{
    Task<IEnumerable<BlogListItemDto>> GetAllAsync();
    Task<BlogDetailDto> GetById(int id);
    Task CreateAsnyc(BlogCreateDto createDto);
    Task UpdateAsnyc(int id, BlogUpdateDto updateDto);
    Task Delete(int id);
}
