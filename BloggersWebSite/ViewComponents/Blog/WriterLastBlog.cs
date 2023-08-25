using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var entity = bm.GetBlogsListByWriter(1);
			return View(entity);
		}
	}
}
