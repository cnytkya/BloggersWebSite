using BloggersWebSite.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace BloggersWebSite.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWritergRepository());

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            AppDbContext dc = new AppDbContext();
            var writerName = dc.Writers.Where(x=>x.WriterMail == usermail).Select(y=>y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        } 
    
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddWriterImageFile p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newımagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImagesFiles", newımagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newımagename;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            w.Location = p.Location;
            wm.Add(w);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            AppDbContext dc = new AppDbContext();
            var usermail = User.Identity.Name;
            var writerId = dc.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var entity = wm.GetById(writerId);
            return View(entity);
        }
  
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult valid = wv.Validate(writer);
            if (valid.IsValid)
            {
                wm.Update(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}
