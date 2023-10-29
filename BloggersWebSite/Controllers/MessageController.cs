using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        
        Message2Manager m2 = new Message2Manager(new EfMessage2Repository());
        public IActionResult InBox()
        {
            int id = 2;
            var values = m2.GetInboxListByWriter(id);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var values = m2.GetById(id);
            return View(values);
        }
    }
}
