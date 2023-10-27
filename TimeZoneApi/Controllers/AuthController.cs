using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using TimeZone.Business.Dtos.UserDtos;
using TimeZone.Business.Services.Interfaces;
using System.Text;
using TimeZone.Business.Exceptions.UserException;
using TimeZone.Business.Exceptions.UserExceptions;
using TimeZone.Core.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    readonly IUserService _userService;
    readonly IMapper _mapper;
    readonly UserManager<AppUser> _userManager;
    readonly SignInManager<AppUser> _signInManager;

    public AuthController(IUserService userService, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userService = userService;
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromForm]RegisterDto dto)
    {
        var user = _mapper.Map<AppUser>(dto);
        if (await _userManager.Users.AnyAsync(u => dto.UserName == u.UserName || dto.Email == u.Email))
            throw new UserExistException();
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description + " ");
            }
            throw new RegisterFailedException(sb.ToString().TrimEnd());
        }
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        string callbackUrl = Url.ActionLink(nameof(VerifyEmail), "Auth", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());
        string body = "You can verify your email address by clicking on this link: <a href=\"" + callbackUrl + "\">Click here</a>";


        var mail = new MailMessage();
        mail.From = new MailAddress("adil.tehranli0@gmail.com", "TimeZone");
        mail.To.Add(new MailAddress(user.Email));
        mail.Subject = "Confirm Email";
        mail.Body = body;
        mail.IsBodyHtml = true;

        using (var smtp = new SmtpClient())
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("adil.tehranli0@gmail.com", "rshzfqxpqaefvvnc");
            await smtp.SendMailAsync(mail);
        }
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
       return Ok( await _userService.LoginAsync(dto));
    }
    [HttpGet]
    [AllowAnonymous]
    [Route("VerifyEmail")]
    public async Task<IActionResult> VerifyEmail(string email, string token)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return BadRequest();
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, true);
            return Redirect("http://localhost:3000/");
        }
        else
        {
            return BadRequest();


        }
    }
    }
