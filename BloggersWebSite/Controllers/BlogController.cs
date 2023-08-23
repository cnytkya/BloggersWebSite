using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.Controllers
{
	public class BlogController : Controller
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IActionResult Index()
		{
			var entity = bm.GetBlogsWithCategories();
			return View(entity);
		}
		
		public IActionResult BlogReadAll(int id)
		{
			ViewBag.Id = id;
			var entity = bm.GetBlogById(id);
			return View(entity);
		}
	}
}
