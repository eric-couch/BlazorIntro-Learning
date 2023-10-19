using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BlazorIntro.Server.Models;
using BlazorIntro.Server.Data;
using BlazorIntro.Shared;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace BlazorIntro.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;

    public AdminController( UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    [HttpGet]
    public async Task<List<UserRolesDto>> Get()
    {
        var users = _userManager.Users.Select(u => new UserRolesDto()
        {
            Id = u.Id,
            UserName = u.UserName,
            Email = u.Email,
            Roles = _userManager.GetRolesAsync(u).Result.ToArray()
        }).ToList();


        return users;
    }
}
