using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BloggersWebSite.Controllers
{
    public class CommentsController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            cm.CommentAdd(comment);
            return PartialView();
        }
        
        public PartialViewResult CommentListByBlog(int id)
        {
            var entity = cm.GetList (id);
            return PartialView(entity);
        }
    }
}
