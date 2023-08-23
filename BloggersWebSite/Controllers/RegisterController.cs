using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
