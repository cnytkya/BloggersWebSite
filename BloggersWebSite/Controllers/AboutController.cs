using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.Controllers
{
	public class AboutController : Controller
	{
		AboutManager am = new AboutManager(new EfAboutRepository());

		public IActionResult Index()
		{
            var x = am.GetList();
            return View(x);
		}
		
		public PartialViewResult SociaLMediaAbout()
		{
			return PartialView();
		}
	}
}
