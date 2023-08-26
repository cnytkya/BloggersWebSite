using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BloggersWebSite.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());  
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.ContactStatus = true;
            cm.ContactAdd(contact);
            return RedirectToAction("Index", "Blog");
        }
    }
}
