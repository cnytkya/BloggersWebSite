﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloggersWebSite.Controllers
{
	[AllowAnonymous]
	public class CategoryController : Controller
	{
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());
		public IActionResult Index()
		{
			var values = cm.GetList();
			return View(values);
		}
	}
}
