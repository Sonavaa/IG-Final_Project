using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    public class ReelsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
