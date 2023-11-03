using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BloggersWebSite.Areas.Admin.Controllers
{
    [Area("Admin")] //Buranın Area-Admin olduğunu programa bildiriyoruz.
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult CategoryAdminIndex(int paged=1)
        {
            var values = cm.GetList().ToPagedList(paged,4);
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult validationResult = validator.Validate(category);
            if(validationResult.IsValid)
            {
                category.CategoryStatus = true;
                cm.Add(category);
                return RedirectToAction("CategoryAdminIndex", "Category");
            }
            else
            {
                foreach(var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = cm.GetById(id);

            if (category == null)
            {
                return NotFound(); // Kategori bulunamadıysa 404 hatası döndür
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult validationResult = validator.Validate(category);

            if (validationResult.IsValid)
            {
                cm.Update(category);
                return RedirectToAction("CategoryAdminIndex", "Category");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = cm.GetById(id);
            cm.Delete(category);
            return RedirectToAction("Index");
        }


    }
}
