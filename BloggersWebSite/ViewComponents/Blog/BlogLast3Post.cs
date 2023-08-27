using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var entity = bm.GetLast3Blog();
            return View(entity);
        }
    }
}
