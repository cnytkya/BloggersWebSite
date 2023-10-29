using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BloggersWebSite.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWritergRepository());
        AppDbContext dc = new AppDbContext();
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            var writerId = dc.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var entity = wm.GetWriterById(writerId);
            return View(entity);
        }
    }
}
