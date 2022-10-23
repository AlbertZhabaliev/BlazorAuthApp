using BlazorAuthApp.Shared;
using Microsoft.AspNetCore.Identity;

namespace BlazorAuthApp.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<AppUser> AppUsers { get; set; } = new();
    }
}