using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.ProductDtos;

namespace TimeZone.Business.Services.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductListItemDto>> GetAllAsync();
    Task<ProductDetailDto> GetById(int id);
    Task CreateAsnyc(ProductCreateDto createDto);
    Task UpdateAsnyc(int id, ProductUpdateDto updateDto);
    Task Delete(int id);
}
