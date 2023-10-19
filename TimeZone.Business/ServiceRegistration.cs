using BlogProject.Business.ExtensionServices.Implements;
using BlogProject.Business.ExtensionServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TimeZone.Business.Services.Implements;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;

namespace TimeZone.Business
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
           services.AddScoped<ISliderService,SliderService>();
           services.AddScoped<IFileService,FileService>();
           services.AddScoped<IBrandService,BrandService>();
           services.AddScoped<ICategoryService,CategoryService>();
           services.AddScoped<IProductService,ProductService>();
           services.AddScoped<IBlogService,BlogService>();
           services.AddScoped<IWrapperService,WrapperService>();
           services.AddScoped<IBannerService,BannerService>();
           services.AddScoped<IUserService,UserService>();
           services.AddScoped<IContactService,ContactService>();
           services.AddScoped<IRoleService,RoleService>();
        }
    }
}
