using Instagram.Data;
using Instagram.FileExtension;
using Instagram.Models;
using Instagram.ViewModels.SettingsViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;

namespace Instagram.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        public SettingsController(UserManager<AppUser> userManager, AppDbContext context, SignInManager<AppUser> signInManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _env = env;
        }
        public IActionResult Index()
        {
            AppUser appUser =  _context.Users
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (appUser == null) return BadRequest();

            SettingsVm settingsVM = new SettingsVm
            {
                User = appUser,
            };

            return View(settingsVM);
        }

        public async Task<IActionResult> EditProfile()
        {
            AppUser appUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (appUser == null) return BadRequest();

            SettingsVm settingsVm = new SettingsVm
            {
                User = appUser,
            };

            return View(settingsVm);
        }

        public async Task<IActionResult> UpdateProfile(SettingsVm settings)
        {
            SettingsVm settingsVM = new SettingsVm
            {
                User = settings.User,
            };

            AppUser dbAppUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditProfile", settingsVM);
            }
    
            return Ok();
        }
    }
}
