using AutoMapper;
using TimeZone.Business.Dtos.BlogDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Profiles
{
    public class BlogMappingProfiles : Profile
    {
        public BlogMappingProfiles()
        {
            CreateMap<Blog, BlogListItemDto>()
            .ForMember(dest => dest.BlogImage, opt => opt.MapFrom(src => src.BlogImage));

            CreateMap<Blog, BlogDetailDto>();
                //.ForMember(dest => dest.BlogImage, opt => opt.MapFrom(src => src.Id)); 

            CreateMap<BlogCreateDto, Blog>();
            CreateMap<BlogUpdateDto, Blog>();
        }
    }

}

