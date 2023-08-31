using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
