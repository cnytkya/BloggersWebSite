using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloggersWebSite.Controllers
{
    public class BlogController : Controller
	{
        AppDbContext dc = new AppDbContext();
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

		[AllowAnonymous]
        public IActionResult Index()
		{
			var entity = bm.GetBlogsWithCategory();
			return View(entity);
		}
		
		public IActionResult BlogReadAll(int id)
		{
			ViewBag.Id = id;
			var entity = bm.GetBlogById(id);
			return View(entity);
		}

		public IActionResult BlogListByWriter()
		{
			var usermail = User.Identity.Name;
			var writerdId = dc.Writers.Where(x=>x.WriterMail == usermail).Select(y=>y.WriterId).FirstOrDefault();
            var entity =  bm.GetListWithCategoryByWriterBM(writerdId);
			return View(entity);
		}

		[HttpGet]
		public IActionResult Create()
		{
			List<SelectListItem> categories = (from x in cm.GetList()
											   select new SelectListItem
											   {
												   Text=x.CategoryName,
												   Value=x.CategoryId.ToString()
											   }).ToList();
			ViewBag.cv = categories;								  
			return View();
		}
		
		[HttpPost]
		public IActionResult Create(Blog blog)
		{
            var usermail = User.Identity.Name;
            var writerdId = dc.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
			ValidationResult validationResult = bv.Validate(blog);
			if (validationResult.IsValid)
			{
				blog.BlogStatus = true;
				blog.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				blog.WriterId = writerdId;
				bm.Add(blog);
				return RedirectToAction("BlogListByWriter", "Blog");			
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
            var blog = bm.GetById(id); // Id'ye göre mevcut blogu al
            List<SelectListItem> categories = (from x in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.cv = categories;

            if (blog == null)
            {
                return NotFound(); // Eğer blog bulunamazsa 404 hatası dön
            }

            return View(blog);
        }

        [HttpPost]
        public IActionResult Update(Blog updatedBlog)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult validationResult = bv.Validate(updatedBlog);

            if (validationResult.IsValid)
            {
                var existingBlog = bm.GetById(updatedBlog.BlogId); // Mevcut blogu al
                if (existingBlog != null)
                {
                    existingBlog.BlogTitle = updatedBlog.BlogTitle;
                    existingBlog.CreatedDate = updatedBlog.CreatedDate;
                    existingBlog.BlogTContent = updatedBlog.BlogTContent;
                    existingBlog.BlogImage = updatedBlog.BlogImage;
					existingBlog.BlogStatus = updatedBlog.BlogStatus;
					existingBlog.CategoryId = updatedBlog.CategoryId;
					existingBlog.WriterId = updatedBlog.WriterId;

					// Diğer güncellenecek alanları da burada güncelleyebilirsiniz

					bm.Update(existingBlog); // Güncelleme işlemini yap
                    return RedirectToAction("BlogListByWriter");
                }
                else
                {
                    ModelState.AddModelError("", "Güncellenmek istenen blog bulunamadı.");
                }
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(updatedBlog);
        }

		public ActionResult Delete(int id)
		{
			var blog = bm.GetById(id);
			bm.Delete(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
