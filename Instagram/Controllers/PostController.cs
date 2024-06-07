using Instagram.Data;
using Instagram.FileExtension;
using Instagram.Models;
using Instagram.ViewModels.PostViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Instagram.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;

        public PostController(AppDbContext context, IWebHostEnvironment env, UserManager<AppUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }
        //Posta klikleyende acilan Modal View
        public async Task<IActionResult> Index(int id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            PostVm postVM = new PostVm
            {
                MyProfile = await _context.Users
                .FirstOrDefaultAsync(c => c.UserName == User.Identity.Name),

                Post = await _context.Posts
                //.Include(p => p.Comments.OrderBy(c => c.CreatedAt).Where(c => c.IsDeleted == false))
                //.ThenInclude(c => c.User)
                .Include(p => p.Saved.Where(c => c.IsDeleted == false))
                .Include(p => p.Likes.Where(pd => pd.IsDeleted == false))
                .ThenInclude(u => u.User)
                .Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id)

            };

            if (postVM.Post == null || postVM.MyProfile == null)
            {
                return NotFound();
            }

            return View(postVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(p => p.UserName == User.Identity.Name);
           

            PostCreateVm postVm = new PostCreateVm
            {
                MyProfile = user
            };

            //if (user == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View(postVm);
        }
            
        [HttpPost]
        public async Task<IActionResult> Create(PostCreateVM vm)
        {
            //AppUser user = await _userManager.Users.FirstOrDefaultAsync(p => p.UserName == User.Identity.Name);


            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //user = await _userManager.FindByIdAsync(userId);


            //if (!ModelState.IsValid)
            //{
            //    return View(Userpost);
            //}

            //if (Userpost.File != null)
            //{
            //    if (Userpost.File == null)
            //    {
            //        ModelState.AddModelError("File", "Add Post.");
            //    }

            //    //if (post.File.CheckFileType("video"))
            //    //{
            //    //    post.IsReels = true;
            //    //}

            //    if (!Userpost.File.CheckFileSize(10))
            //    {
            //        ModelState.AddModelError("", "File Must Be Less Than 10MB!");
            //        return View(Userpost);
            //    }
            //}
            //string uniqueFileName = await Userpost.File.SaveFilesAsync(_env.WebRootPath, "client", "assets", "images", "photos");

            //Post newpost = new Post
            //{
            //    PostUrl = uniqueFileName,
            //    CreatedAt = DateTime.UtcNow.AddHours(4),
            //    CreatedBy = user.Fullname,
            //    UserId = user.Id,
            //    Caption = Userpost.Caption
            //};

            //if (newpost.Caption == null)
            //{
            //    newpost.Caption = "";
            //}

            //await _context.Posts.AddAsync(newpost);


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user=await _userManager.FindByIdAsync(userId);

            if(user is  null)
            {
                return BadRequest();
            }

            Post post = new()
            {
                 Caption = vm.Caption,
                 PostUrl =vm.Base64,
                 CreatedAt=DateTime.UtcNow,
                 CreatedBy=user.UserName,
                 UserId=userId

            };


            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        public async Task<IActionResult> Update(int id)
        {
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Delete(int id)
        {
            Post? post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post is null)
            {
                return NotFound();
            }

            post.IsDeleted = true;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public async Task<IActionResult> Like(int? id)
        {
            if (id == null) return BadRequest();

            Post post = await _context.Posts.Include(p => p.Likes.Where(l => l.IsDeleted == false)).FirstOrDefaultAsync(p => p.Id == id);

            AppUser postOwner = await _context.Users.FirstOrDefaultAsync(p => p.Id == post.UserId);

            if (post == null) return NotFound();

            AppUser user = await _userManager.Users.FirstOrDefaultAsync(p => p.UserName == User.Identity.Name);

            bool isLiked = post.Likes.Any(l => l.UserId == user.Id && l.PostId == post.Id);

            if (!isLiked)
            {
               Like like = new Like
                {
                    UserId = user.Id,
                    PostId = post.Id,
                    IsDeleted = false,
                };
 
                post.Likes.Add(like);

            }

            await _context.SaveChangesAsync();
            return Json(post.Likes.Count());
        }
    }

}



// Butun Crudlarda silinen adlari yeniden yaratmaq olmur yeniden yaratmaq ucun isdeleted false sertini ver
//nomrelemeni orderbydescending ele



//public async Task<IActionResult> Detail(int? id)