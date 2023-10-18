using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
    readonly IConfiguration _configuration;
    public UserService(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration)
    {
        _userManager = userManager;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
       var user =await _userManager.FindByNameAsync(dto.UserName);
        if (user == null) throw new LoginFailedException("Username or password is wrong");
        var result = await _userManager.CheckPasswordAsync(user,dto.Password);
        if (!result) throw new LoginFailedException("Username or password is wrong");

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,user.Name),
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.GivenName,user.Name),
            new Claim(ClaimTypes.Surname,user.Surname),

        };
        SymmetricSecurityKey securityKey = new (Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
        SigningCredentials credentials =new (securityKey,SecurityAlgorithms.HmacSha256);
        JwtSecurityToken jwttoken = new (
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims, DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(60),
            credentials);
        JwtSecurityTokenHandler handler = new ();
      string token = handler.WriteToken(jwttoken);
        return token;
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
