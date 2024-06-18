using Instagram.Data;
using Instagram.FileExtension;
using Instagram.Models;
using Instagram.ViewModels.SettingsViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;


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

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(SettingsVm settings)
        {
            SettingsVm settingsVM = new SettingsVm
            {
                User = settings.User,
            };

            AppUser dbAppUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditProfile", settingsVM);
            }

            if (settings.User.File != null)
            {
                if (!settings.User.File.CheckFileType("image"))
                {
                    ModelState.AddModelError("File", "File must be image type!");
                    return View(dbAppUser);
                }

                //Secdiyim sekillerin olcusu boyuk olduguna gore checkFileSize yoxlanisini etmirem

                //if (!settings.User.File.CheckFileSize(10))
                //{
                //    ModelState.AddModelError("File", "File must be less than 10MB!");
                //    return View(dbAppUser);
                //}

                settings.User.File.DeleteFile(_env.WebRootPath, "client", "assets", "images", "profile-photos", dbAppUser.ProfilePic);

                var filename = await settings.User.File.SaveFilesAsync(_env.WebRootPath, "client", "assets", "images", "profile-photos");
                dbAppUser.ProfilePic = filename;
            }

            if (_context.Users.Any(u => u.UserName.ToLower().Trim() == settings.User.UserName.ToLower().Trim()))
            {
                if (dbAppUser.UserName != settings.User.UserName)
                {
                    ModelState.AddModelError("", $"{settings.User.UserName} Already Taken. Choose Another One!");
                    return View("EditProfile", settingsVM);
                }
                else
                {
                    dbAppUser.UserName = settings.User.UserName.Trim();
                }
            }
            else
            {
                dbAppUser.UserName = settings.User.UserName.Trim();
                dbAppUser.NormalizedUserName = settings.User.UserName.ToUpperInvariant().Trim();
            }
            dbAppUser.Bio = settings.User.Bio;
            dbAppUser.Gender = settings.User.Gender;


            _context.Update(dbAppUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("MyProfile", "Profile");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProfilePhoto(string? id)
        {
            if (id == null) return BadRequest();

            AppUser appUser = _context.Users.FirstOrDefault(U => U.Id == id);

            if (appUser == null) return NotFound();

            appUser.ProfilePic = "no-profile-photo.jpg";

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EditProfile));
        }

    }
}
