using AutoMapper;
using TimeZone.Business.Dtos.CategoryDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles
{
    public class CategoryMappingProfiles : Profile
    {
        public CategoryMappingProfiles()
        {
            CreateMap<Category,CategoryListItemDto>();
            CreateMap<Category,CategoryDetailDto>();
            CreateMap<CategoryCreateDto,Category>();
            CreateMap<CategoryUpdateDto,Category>();
        }
    }
}
