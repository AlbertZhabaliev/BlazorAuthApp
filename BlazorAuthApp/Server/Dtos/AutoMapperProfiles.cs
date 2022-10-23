using AutoMapper;
using BlazorAuthApp.Server.Models;
using BlazorAuthApp.Shared;

namespace BlazorAuthApp.Server.Dtos
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
            CreateMap<ApplicationUser, AppUser>();
        }
	}
}
