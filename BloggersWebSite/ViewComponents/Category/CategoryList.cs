using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        
        public IViewComponentResult Invoke()
        {
            var entity = cm.GetList();
            return View(entity);  
        }
    }
}
