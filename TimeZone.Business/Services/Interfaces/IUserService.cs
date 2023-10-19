using TimeZone.Business.Dtos.UserDtos;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Services.Interfaces;

public interface IUserService
{
    Task RegisterAsync(RegisterDto dto);
    Task<string> LoginAsync(LoginDto dto);
    Task<ICollection<UserWithRoleDto>> GetAllAsync();
    Task AddRole(string roleName, string userName);
    Task RemoveRole(string roleName, string userName);
}
