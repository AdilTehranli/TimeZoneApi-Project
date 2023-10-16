using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TimeZone.Business.Dtos.UserDtos;
using TimeZone.Business.Exceptions.UserException;
using TimeZone.Business.Exceptions.UserExceptions;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;

namespace TimeZone.Business.Services.Implements;

public class UserService : IUserService
{
    readonly UserManager<AppUser> _userManager;
    readonly IMapper _mapper;
    public UserService(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        var user= _mapper.Map<AppUser>(dto);
        if (await _userManager.Users.AnyAsync(u => dto.UserName == u.UserName || dto.Email == u.Email))
            throw new UserExistException();
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded) {
           StringBuilder sb = new StringBuilder();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description + " ");
            }
            throw new RegisterFailedException(sb.ToString().TrimEnd());
        }
    }
}
