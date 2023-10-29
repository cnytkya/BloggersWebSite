using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    { 
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int id = 2;
            //p = "deneme2542@gmail.com"; //burası aslında session dan gelen bir değer olacak
            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }
    }
}
