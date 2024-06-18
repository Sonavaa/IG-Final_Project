using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    public class ExploreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
