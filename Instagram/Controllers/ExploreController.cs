using Instagram.Data;
using Instagram.Models;
using Instagram.ViewModels.HomeViewModel;
using Instagram.ViewModels.PostViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Controllers
{
    public class ExploreController : Controller
    {
        private readonly AppDbContext _context;

        public ExploreController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            PostsVm postsVM = new PostsVm
            {
                Posts = await _context.Posts
                    .Include(c => c.Likes.Where(l => l.IsDeleted == false))
                    .Include(p => p.Saved)
                    .Include(u => u.User)
                    .ThenInclude(b => b.Followings)
                    .Include(u => u.User)
                    .ThenInclude(b => b.Followers)
                    .Where(p => p.IsDeleted == false).OrderByDescending(c => c.CreatedAt).ToListAsync(),
                MyProfile = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name)
            };

            HomeVm homeVM = new HomeVm
            {
                Posts = postsVM,
            };

            return View(homeVM);
        }

    }
}
