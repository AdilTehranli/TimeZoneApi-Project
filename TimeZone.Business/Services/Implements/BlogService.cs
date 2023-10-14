using AutoMapper;
using BlogProject.Business.ExtensionServices.Interfaces;
using TimeZone.Business.Dtos.BlogDtos;
using TimeZone.Business.Dtos.ProductDtos;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;
using TimeZone.DAL.Repositories.Implements;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class BlogService : IBlogService
{
    readonly IBlogRepository _blogRepository;
    readonly IFileService _fileService;
    readonly IMapper _mapper;

    public BlogService(IBlogRepository blogRepository, IFileService fileService, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task CreateAsnyc(BlogCreateDto createDto)
    {
        if (createDto == null)
        {
            throw new NullReferenceException("Data is null");
        }
        var mapper = _mapper.Map<Blog>(createDto);
        mapper.BlogImage = await _fileService.UploadAsync(createDto.BlogImage, Path.Combine("images"));
        if (mapper == null)
        {
            throw new NullReferenceException("Mapper is null");
        }

        await _blogRepository.CreateAsync(mapper);
        await _blogRepository.SaveAsync();
    }

    public async Task Delete(int id)
    {
        await _blogRepository.DeleteAsync(id);
        await _blogRepository.SaveAsync();
    }

    public async Task<IEnumerable<BlogListItemDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<BlogListItemDto>>(_blogRepository.GetAll());
    }

    public async Task<BlogDetailDto> GetById(int id)
    {
        var entity = await _getBlogAsync(id);
        return _mapper.Map<BlogDetailDto>(entity);
    }

    public async Task UpdateAsnyc(int id, BlogUpdateDto updateDto)
    {
        if (id < 1)
        {
            throw new ArgumentException("Invalid ID. ID should be greater than or equal to 1.");
        }
        var entity = await _blogRepository.FindByIdAsync(id);
        if (entity == null)
        {
            throw new NullReferenceException("not exist entity");
        }

        entity.BlogImage = await _fileService.UploadAsync(updateDto.BlogImage, Path.Combine("images"));
        entity.Title = updateDto.Title;
        entity.Description = updateDto.Description;

        await _blogRepository.UpdateAsync(entity);
        await _blogRepository.SaveAsync();
    }
    async Task<Blog> _getBlogAsync(int id)
    {
        if (id <= 0) throw new ArgumentException();
        var entity = await _blogRepository.FindByIdAsync(id);
        if (entity == null) throw new NullReferenceException();
        return entity;
    }
}
