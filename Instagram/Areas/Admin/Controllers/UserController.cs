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
            var users = await _context.Users
                .Include(u => u.Followers)
                .ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
            {
                return NotFound();
            }


            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "User");
        }
    }
}
