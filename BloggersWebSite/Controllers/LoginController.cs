using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
