using TimeZone.Business.Dtos.UserDtos;

namespace TimeZone.Business.Services.Interfaces;

public interface IUserService
{
    Task RegisterAsync(RegisterDto dto);
    Task<string> LoginAsync(LoginDto dto);
}
