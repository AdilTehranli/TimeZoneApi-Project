using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeZone.Business.Exceptions.Role;
using TimeZone.Business.Services.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class RoleService : IRoleService
{
    readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task CreateAsnyc(string name)
    {
        if (await _roleManager.RoleExistsAsync(name)) throw new RoleExistException();

        var result = await _roleManager.CreateAsync(new IdentityRole
        {
            Name = name
        });
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

    public async Task Delete(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null) throw new ArgumentException();
        var result = await _roleManager.DeleteAsync(role);
        if (!result.Succeeded)
        {
            string a = String.Empty;
            foreach (var err in result.Errors)
            {
                a += err.Description + " ";
            }
            throw new Exception(a);
        }
    }

    public async Task<IEnumerable<IdentityRole>> GetAllAsync()
    {
        return await _roleManager.Roles.ToListAsync();
    }

    public async Task<string> GetById(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null) throw new NullReferenceException();
        return role.Name;
    }

    public async Task UpdateAsnyc(string id, string name)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null) throw new ArgumentException();
        role.Name = name;
        var result = await _roleManager.UpdateAsync(role);
        if (!result.Succeeded)
        {
            string a = String.Empty;
            foreach (var err in result.Errors)
            {
                a += err.Description + " ";
            }
            throw new Exception(a);
        }
    }
}
