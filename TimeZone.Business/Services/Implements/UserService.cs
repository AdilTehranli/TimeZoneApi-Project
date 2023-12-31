﻿using AutoMapper;
using Azure.Core;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using TimeZone.Business.Dtos.UserDtos;
using TimeZone.Business.Exceptions.Commons;
using TimeZone.Business.Exceptions.Role;
using TimeZone.Business.Exceptions.UserException;
using TimeZone.Business.Exceptions.UserExceptions;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;
using TimeZone.DAL.Contexts;

namespace TimeZone.Business.Services.Implements;

public class UserService : IUserService
{
    readonly UserManager<AppUser> _userManager;
    readonly IMapper _mapper;
    readonly IConfiguration _configuration;
    readonly RoleManager<IdentityRole> _roleManager;
    readonly IRoleService _roleService;
    readonly SignInManager<AppUser> _signInManager;
    readonly AppDbContext _dbcontext;
    public UserService(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration, RoleManager<IdentityRole> roleManager, IRoleService roleService, SignInManager<AppUser> signInManager, AppDbContext dbcontext)
    {
        _userManager = userManager;
        _mapper = mapper;
        _configuration = configuration;
        _roleManager = roleManager;
        _roleService = roleService;
        _signInManager = signInManager;
        _dbcontext = dbcontext;
    }

    public async Task AddRole(string roleName, string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null) throw new NotFoundException<AppUser>();
        if (!await _roleManager.RoleExistsAsync(roleName)) throw new NotFoundException<IdentityRole>();
        var result = await _userManager.AddToRoleAsync(user, roleName);
        if (!result.Succeeded)
        {
            string a = "";
            foreach (var err in result.Errors)
            {
                a += err.Description + " ";
            }
            throw new RoleCreateFailedException(a);
        }
    }


    public async Task<ICollection<UserWithRoleDto>> GetAllAsync()
    {
        ICollection<UserWithRoleDto> users = new List<UserWithRoleDto>();
        foreach (var user in await _userManager.Users.ToListAsync())
        {
            users.Add(new UserWithRoleDto
            {
                User = _mapper.Map<AuthorDto>(user),
                Roles = await _userManager.GetRolesAsync(user)
            });
        }
        return users;
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
        foreach(var userRole in _roleService.GetAllAsync().Result)
        {
            claims.Add(new Claim(ClaimTypes.Role, userRole.Name));
        }
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
        
     

    }
    public async Task VerifyEmail(string email, string token)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            throw new NullReferenceException();
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            user.EmailConfirmed = true;
            _dbcontext.SaveChanges();
            await _signInManager.SignInAsync(user, true);
        }
        else
        {
            throw new Exception();
        }
    }

    public Task RemoveRole(string roleName, string userName)
    {
        throw new NotImplementedException();
    }

}
