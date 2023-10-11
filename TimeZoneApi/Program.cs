using Microsoft.EntityFrameworkCore;
using TimeZone.Business;
using TimeZone.Business.Profiles;
using TimeZone.DAL;
using TimeZone.DAL.Contexts;
using Microsoft.Extensions.DependencyInjection;
using TimeZone.Business.Services.Implements;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.FileProviders;
using ServiceStack.Text;
using TimeZone.Core.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(pol =>
    {
        pol.WithOrigins("http://localhost:3000/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssemblyContaining<SliderService>();
});
builder.Services.AddServices();

builder.Services.AddAutoMapper(typeof(SliderMappingProfiles).Assembly);
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
