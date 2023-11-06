using AutoMapper;
using BlogProject.Business.ExtensionServices.Implements;
using BlogProject.Business.ExtensionServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using TimeZone.Business.Dtos.ProductDtos;
using TimeZone.Business.Dtos.SliderDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class ProductService : IProductService
{
    readonly IProductRepository _productRepository;
    readonly IFileService _fileService;
    readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IFileService fileService, IMapper mapper)
    {
        _productRepository = productRepository;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task CreateAsnyc(ProductCreateDto createDto)
    {
        if (createDto == null)
        {
            throw new NullReferenceException("Data is null");
        }
        var mapper = _mapper.Map<Product>(createDto);
        mapper.ProductImage = await _fileService.UploadAsync(createDto.ProductImage, Path.Combine("images"));
        if (mapper == null)
        {
            throw new NullReferenceException("Mapper is null");
        }

        await _productRepository.CreateAsync(mapper);
        await _productRepository.SaveAsync();
    }

    public async Task Delete(int id)
    {
        await _productRepository.DeleteAsync(id);
        await _productRepository.SaveAsync();
    }

    public async Task<IEnumerable<ProductListItemDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ProductListItemDto>>(
        _productRepository.Table.Include(c => c.Category).Include(b => b.Brand).ToList()) ;
        
    }

    public async Task<ProductDetailDto> GetById(int id)
    {
        var entity = await _getProductAsync(id);
        if(entity == null)
        {
            throw new NullReferenceException("Bosdur");
        }
       await _productRepository.Table.Include(c => c.Category).Include(b => b.Brand).FirstOrDefaultAsync(p=>p.Id==id);
       return _mapper.Map<ProductDetailDto>(entity);
    }

    public async Task UpdateAsnyc(int id, ProductUpdateDto updateDto)
    {
        if (id < 1)
        {
            throw new ArgumentException("Invalid ID. ID should be greater than or equal to 1.");
        }
        var entity = await _productRepository.FindByIdAsync(id);
        if (entity == null)
        {
            throw new NullReferenceException("not exist entity");
        }

        entity.ProductImage = await _fileService.UploadAsync(updateDto. ProductImage, Path.Combine("images"));
        entity.Title = updateDto.Title;
        entity.Price = updateDto.Price;
        entity.CategoryId = updateDto.CategoryId;
        entity.BrandId = updateDto.BrandId;

        await _productRepository.UpdateAsync(entity);
        await _productRepository.SaveAsync();
    }
    async Task<Product> _getProductAsync(int id)
    {
        if (id <= 0) throw new ArgumentException();
        var entity = await _productRepository.FindByIdAsync(id);
        if (entity == null) throw new NullReferenceException();
        return entity;
    }
}
