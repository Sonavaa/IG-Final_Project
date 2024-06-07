using Instagram.Data;
using Instagram.Models;
using Instagram.ViewModels.MessageViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public MessageController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            //List<MyDirect> myDirect = await _context.MyDirect
            //    .Include(c => c.WriteingWithUser)
            //    .Include(c => c.AppUser)
            //    .Include(c => c.Messages)
            //    .Where(c => c.WriteingWithUserId == appUser.Id || c.AppUserId == appUser.Id).ToListAsync();

            //ViewBag.MyId = $"{appUser.Id}";

            //DirectVm directVM = new DirectVm
            //{
            //    MyProfile = appUser,
            //    MyDirects = myDirect,
            //};

            //return View(directVM);
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }
    }
}
