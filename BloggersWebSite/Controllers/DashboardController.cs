using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BloggersWebSite.Controllers
{

    public class DashboardController : Controller
    {
        BlogManager blogManager=new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            AppDbContext dbContext = new AppDbContext();
            ViewBag.v1 = dbContext.Blogs.Count().ToString();
            ViewBag.v2 = dbContext.Blogs.Where(x=>x.WriterId==1).Count();
            ViewBag.v3 = dbContext.Categories.Count().ToString();
            return View();
        }
    }
}
