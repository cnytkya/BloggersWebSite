using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BloggersWebSite.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        AppDbContext context = new AppDbContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Admins.Where(x=>x.AdminId==1).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = context.Admins.Where(x => x.AdminId == 1).Select(x => x.ImageUrl).FirstOrDefault();
            //ViewBag.v2 = context.Admins.Where(x => x.AdminId == 1).Select(x => x.Description).FirstOrDefault();
            return View();
        }
    }
}
