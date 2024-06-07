using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    public class StoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
