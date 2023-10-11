﻿using BlogProject.Business.ExtensionServices.Implements;
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
        }
    }
}
