using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.Controllers
{
    public class CommentsController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        
        public PartialViewResult CommentListByBlog(int id)
        {
            var entity = cm.GetList (id);
            return PartialView(entity);
        }
    }
}
