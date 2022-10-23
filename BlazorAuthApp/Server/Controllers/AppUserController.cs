using BlazorAuthApp.Server.Data;
using BlazorAuthApp.Server.Data.Migrations;
using BlazorAuthApp.Shared;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BlazorAuthApp.Server.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace BlazorAuthApp.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AppUserController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }
    

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<AppUser>>> Get()
        {
            //var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //var user = await _dbContext.Users
            //    .Include(x => x.AppUsers)
            //    .FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            //var users = _dbContext.Users;
            var users = _dbContext.Users.Select(x => _mapper.Map<AppUser>(x));
            if (users == null)
            {
                var dummyList = Enumerable.Empty<ApplicationUser>().ToList();
                return NotFound(dummyList);
            }
            return Ok(users);
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<List<AppUser>>> UpdateUser(string id)
        {
            var userToUpdate = await _dbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (userToUpdate == null)
            {
                return NotFound("User not found");
            }
            userToUpdate.LockoutEnabled = !userToUpdate.LockoutEnabled;
            await _dbContext.SaveChangesAsync();
            return Ok(await Get());
        }

    }
}
