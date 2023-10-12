using Microsoft.Extensions.DependencyInjection;
using TimeZone.DAL.Repositories.Implements;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.DAL
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISliderRepository,SliderRepository>();
            services.AddScoped<IBrandRepository,BrandRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
        }
    }
}
