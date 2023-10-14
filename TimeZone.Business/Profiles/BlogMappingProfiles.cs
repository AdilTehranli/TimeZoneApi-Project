using AutoMapper;
using TimeZone.Business.Dtos.BlogDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles
{
    public class BlogMappingProfiles : Profile
    {
        public BlogMappingProfiles()
        {
            CreateMap<Blog, BlogListItemDto>();
            CreateMap<Blog, BlogDetailDto>();
            CreateMap<BlogCreateDto, Blog>();
            CreateMap<BlogUpdateDto, Blog>();
        }
    }

}

