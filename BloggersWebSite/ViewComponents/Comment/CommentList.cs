using BloggersWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BloggersWebSite.ViewComponents.Comment
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvales = new List<UserComment>
            {
                new UserComment
                {
                    Id = 1,
                    UserName="Cüneyt"
                },
                new UserComment
                {
                    Id=2,
                    UserName="Gülçe"
                },
                new UserComment
                {
                    Id=3,
                    UserName="Gürcan"
                }
            };
            return View(commentvales);
        }
    }
}
