using Instagram.Data;
using Instagram.Models;
using Instagram.ViewModels.SettingsViewModel;
using Instagram.ViewModels.UserProfileViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public ProfileController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            AppUser appUser = await _userManager.Users
                .Include(u => u.Followers)
                .ThenInclude(c => c.UserFollower)
                .Include(u => u.Followings)
                .ThenInclude(c => c.UserFollowing)
                .Include(u => u.Posts.Where(p => p.IsDeleted == false).OrderBy(u => u.CreatedAt))
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            return View(appUser);
        }
        [HttpGet]
        public async Task<IActionResult> UserProfile(string? id)
        {

            UserProfileVm userVM = new UserProfileVm
            {
                User = await _userManager.Users
                .Include(u => u.Followers)
                .Include(u => u.Followings)
                .Include(u => u.Posts.Where(p => p.IsDeleted == false).OrderBy(u => u.CreatedAt))
                .FirstOrDefaultAsync(u => u.Id == id),

                MyProfile = await _userManager.Users
                .Include(u => u.Followers)
                .Include(u => u.Followings)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name)
            };

            if (userVM.User.Id == userVM.MyProfile.Id)
            {
                return RedirectToAction(nameof(MyProfile));
            }

            return View(userVM);
        }
        [HttpGet]
        public async Task<IActionResult> RejectFollow(string? id)
        {

            AppUser appUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AcceptFollow(string? id)
        {
            AppUser follower = await _context.Users
                .Include(u => u.Followings)
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(u => u.Id == id);

            AppUser following = await _context.Users
                .Include(u => u.Followings)
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            Follower followerDb = new Follower
            {
                UserId = following.Id,
                UserFollowerId = follower.Id
            };
            Following followingDb = new Following
            {
                UserId = follower.Id,
                UserFollowingId = following.Id
            };

            follower.Followings.Add(followingDb);
            following.Followers.Add(followerDb);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Follow(string? id)
        {
            AppUser following = await _context.Users
                .Include(u => u.Followings)
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(u => u.Id == id);

            AppUser follower = await _context.Users
                .Include(u => u.Followings)
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
        
                Follower followerDb = new Follower
                {
                    UserId = following.Id,
                    UserFollowerId = follower.Id
                };
                Following followingDb = new Following
                {
                    UserId = follower.Id,
                    UserFollowingId = following.Id
                };

                follower.Followings.Add(followingDb);
                following.Followers.Add(followerDb);


            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> UnFollow(string? id)
        {

            AppUser following = await _context.Users
                .Include(u => u.Followings)
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(u => u.Id == id);

            AppUser follower = await _context.Users
                .Include(u => u.Followings)
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            ;
            following.Followers.Remove(following.Followers.FirstOrDefault(f => f.UserId == id));
            follower.Followings.Remove(follower.Followings.FirstOrDefault(f => f.UserId == follower.Id));


            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
