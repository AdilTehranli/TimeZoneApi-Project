using Microsoft.AspNetCore.Identity;
using TimeZone.Business.Dtos.ProductDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<IdentityRole>> GetAllAsync();
    Task<string> GetById(string id);
    Task CreateAsnyc(string name);
    Task UpdateAsnyc(string id, string name);
    Task Delete(string id);
}

