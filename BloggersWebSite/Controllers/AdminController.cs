﻿using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
