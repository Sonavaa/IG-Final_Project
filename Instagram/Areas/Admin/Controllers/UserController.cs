using Instagram.Data;
using Instagram.Models;
using Instagram.FileExtension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Instagram.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public UserController(AppDbContext context, IWebHostEnvironment env)
        {
                _context = context;
                _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppUser User)
        {
            if (ModelState["UserName"] == null ||
                ModelState["Email"] == null ||
                ModelState["Fullname"] == null ||
                ModelState["File"] == null)
            {
                return View(User);
            }
                

            if (await _context.Users.AnyAsync(x => x.UserName == User.UserName))
            {
                ModelState.AddModelError("", "This Username Already Exists!");
                return View(User);
            }

            if (!User.File.CheckFileType("image"))
            {
                ModelState.AddModelError("", "Invalid File");
                return View(User);
            }
            if (!User.File.CheckFileSize(2))
            {
                ModelState.AddModelError("", "Invalid File Size");
                return View(User);
            }


            string uniqueFileName = await User.File.SaveFilesAsync(_env.WebRootPath, "client", "assets", "images", "profile-photos");

            AppUser newuser = new AppUser
            {
                UserName = User.UserName,
                ProfilePic = uniqueFileName,
                Email = User.Email,
                //Password = User.Password,
                //RepeatPassword = User.RepeatPassword,
                Fullname = User.Fullname,
                Bio = User.Bio,
                //CreatedAt = DateTime.UtcNow.AddHours(4),
                //CreatedBy = "Admin"
            };

            await _context.Users.AddAsync(newuser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
