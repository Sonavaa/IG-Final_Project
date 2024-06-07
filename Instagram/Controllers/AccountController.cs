using Instagram.Data;
using Instagram.Enums;
using Instagram.Migrations;
using Instagram.Models;
using Instagram.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Instagram.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVm);
            }

            var existUser = _userManager.FindByNameAsync(registerVm.Username);
            if (existUser == null)
            {
                ModelState.AddModelError("", "This Username Already Exists!");
                return View(registerVm);
            }

            AppUser newUser = new AppUser
            {
                UserName = registerVm.Username,
                Fullname = registerVm.Fullname,
                Email = registerVm.Email,
                Gender = "Man",
                IsPrivate = false,
                İsBlock = false,
                ActivtyStatusIsVisible = false,
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, registerVm.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVm);
            }

            await _userManager.AddToRoleAsync(newUser, "User");
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else if (User.IsInRole("SuperAdmin"))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (User.Identity.IsAuthenticated)
            {
                // Kullanıcı zaten oturum açmışsa ana sayfaya yönlendir
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Model IsValid deyil. Niye?
                if (ModelState.IsValid)
                {
                    return View(loginVm);
                }

                var existUser = await _userManager.FindByEmailAsync(loginVm.Email);

                if (existUser == null)
                {
                    ModelState.AddModelError("", "Sorry, your email or password was incorrect.");
                    return View(loginVm);
                }

                //Hem username hem de emaille daxil ola bilsin
                //var existUser = await _userManager.FindByEmailAsync(loginVm.Email);
                //if (existUser == null)
                //{
                //    // Kullanıcı adı ile kullanıcı bulunamazsa, e-posta adresiyle arayın
                //    existUser = await _userManager.FindByNameAsync(loginVm.Username);
                //}


                var result = await _signInManager.PasswordSignInAsync(existUser, loginVm.Password, false, true);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Sorry, your email or password was incorrect.");
                    return View(loginVm);
                }

                var role = await _userManager.IsInRoleAsync(existUser, Roles.Admin.ToString());
                if (role)
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string id, string token, ResetPasswordVm resetPasswordVM)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return BadRequest();
            }
            IdentityResult identityResult = await _userManager.ResetPasswordAsync(appUser, token, resetPasswordVM.Password);
            if (!identityResult.Succeeded)
            {
                return BadRequest();
            }
            return RedirectToAction("Login", "Acconut");
        }

        [HttpGet]
        public IActionResult Switch()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else if (User.IsInRole("SuperAdmin"))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Switch(LoginVm loginVm)
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

                if (ModelState.IsValid)
                {
                    return View(loginVm);
                }

                var existUser = await _userManager.FindByEmailAsync(loginVm.Email);

                if (existUser == null)
                {
                    ModelState.AddModelError("", "Sorry, your email or password was incorrect.");
                    return View(loginVm);
                }


                var result = await _signInManager.PasswordSignInAsync(existUser, loginVm.Password, false, true);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Sorry, your email or password was incorrect.");
                    return View(loginVm);
                }

                var role = await _userManager.IsInRoleAsync(existUser, Roles.Admin.ToString());
                if (role)
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
            return RedirectToAction("Login", "Account");
        }













        #region CreateRoles
        //[HttpGet]
        //public async Task<IActionResult> CreateRoles()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("User"));

        //    return Content("Successed!");
        //}

        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{
        //    AppUser newUser = new AppUser
        //    {
        //        UserName = "SuperAdmin",
        //        Fullname = "Super Admin",
        //        Email = "superAdmin@gmail.com",
        //    };

        //    await _userManager.CreateAsync(newUser, "superAdmin123@");

        //    await _userManager.AddToRoleAsync(newUser, "Admin");

        //    return Content("Successfully Created!");
        //}

        //[HttpGet]
        //public async Task<IActionResult> CreateA()
        //{
        //    AppUser newUser = new AppUser
        //    {
        //        UserName = "Admin",
        //        Fullname = "Admin",
        //        Email = "sonava@code.edu.az",
        //    };

        //    await _userManager.CreateAsync(newUser, "Admin123");

        //    await _userManager.AddToRoleAsync(newUser, "Admin");

        //    return Content("Successfully Created!");
        //}

        #endregion































    }
}
