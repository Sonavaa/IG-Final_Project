﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NestApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}