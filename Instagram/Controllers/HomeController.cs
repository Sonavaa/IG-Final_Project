using Instagram.Data;
using Instagram.Models;
using Instagram.ViewModels.HomeViewModel;
using Instagram.ViewModels.PostViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            AppUser appUser = await _userManager.Users
                .Include(u => u.Posts)
                .FirstOrDefaultAsync((u => u.UserName == User.Identity.Name));

            //IEnumerable<string> followingIds = appUser.Followings.Select(f => f.UserFollowingId);
            //followingIds = followingIds.Append(appUser.Id);

            AppUser user = await _context.Users.FirstOrDefaultAsync(p => p.UserName == User.Identity.Name);

            IEnumerable<Post> posts = await _context.Posts.Where(p => p.User.IsPrivate == false && !p.IsDeleted).ToListAsync();

            SearchUserVm SearchUserVM = new SearchUserVm
            {
                Users = await _context.Users.Where(u => u.UserName != User.Identity.Name).ToListAsync(),
            };

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
                MyProfile = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name)
            };

            SuggestionsVm suggestionsVM = new SuggestionsVm
            {
                Suggestions = await _context.Users.Where(u => u.UserName != User.Identity.Name).Include(u => u.Followers).Take(5).ToListAsync(),
                MyProfile = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name)
            };

            HomeVm homeVM = new HomeVm
            {
                Posts = postsVM,
                Users = suggestionsVM,
                SearchUser = SearchUserVM,
                MyProfile = appUser
            };

            return View(homeVM);
        }
        public async Task<IActionResult> SearchUser(string? search)
        {
            if (search == null)
            {
                return RedirectToAction(nameof(Index));
            }

            List<AppUser> users = await _context.Users.Where(u => u.UserName.ToLower().Contains(search.ToLower()) || u.Fullname.ToLower().Contains(search.ToLower())).ToListAsync();

            return PartialView("/Views/Home/_SearchUserPartial.cshtml", users);
        }
    }
}
