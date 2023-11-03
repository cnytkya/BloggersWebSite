﻿using BloggersWebSite.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BloggersWebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        
        public IActionResult WriterList()
        {
            var jsonWriter = JsonConvert.SerializeObject(writters);
            return Json(jsonWriter);
        }

        public IActionResult GetWriterById(int writerid)
        {
            var findWriter = writters.FirstOrDefault(x=> x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        public static List<WriterClass> writters = new List<WriterClass>
        {
            new WriterClass()
            {
                Id = 1,
                Name = "Cüneyt",
            },

            new WriterClass()
            {
                Id = 2,
                Name = "Ahmet",
            },
            new WriterClass()
            {
                Id = 3,
                Name = "Yaman",
            }
        };
    }
}