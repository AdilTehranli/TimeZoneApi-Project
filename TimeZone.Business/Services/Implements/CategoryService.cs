using AutoMapper;
using TimeZone.Business.Dtos.BrandDtos;
using TimeZone.Business.Dtos.CategoryDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;
using TimeZone.DAL.Repositories.Implements;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class CategoryService : ICategoryService
{
    readonly ICategoryRepository _categoryRepository;
    readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task CreateAsnyc(CategoryCreateDto createDto)
    {
        if (createDto == null)
        {
            throw new NullReferenceException("Data is null");
        }
        var mapper = _mapper.Map<Category>(createDto);
        if (mapper == null)
        {
            throw new NullReferenceException("Mapper is null");
        }
        await _categoryRepository.CreateAsync(mapper);
        await _categoryRepository.SaveAsync();
    }

    public async Task Delete(int id)
    {
        await _categoryRepository.DeleteAsync(id);
        await _categoryRepository.SaveAsync();
    }

    public async Task<IEnumerable<CategoryListItemDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<CategoryListItemDto>>(_categoryRepository.GetAll());

    }

    public async Task UpdateAsnyc(int id, CategoryUpdateDto updateDto)
    {
        if (id < 1)
        {
            throw new ArgumentException("Invalid ID. ID should be greater than or equal to 1.");
        }
        var entity = await _categoryRepository.FindByIdAsync(id);
        if (entity == null)
        {
            throw new NullReferenceException("not exist entity");
        }

        entity.Name = updateDto.Name;

        await _categoryRepository.UpdateAsync(entity);
        await _categoryRepository.SaveAsync();
    }
}
