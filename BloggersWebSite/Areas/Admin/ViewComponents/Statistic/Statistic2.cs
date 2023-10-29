using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BloggersWebSite.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        AppDbContext dc = new AppDbContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = dc.Blogs.OrderByDescending(x=>x.BlogId).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.v2 = dc.Categories.OrderByDescending(x => x.CategoryId).Select(x => x.CategoryName).Take(1).FirstOrDefault();
            ViewBag.v3 = dc.Comments.Count();
            return View();
        }
    }
}
