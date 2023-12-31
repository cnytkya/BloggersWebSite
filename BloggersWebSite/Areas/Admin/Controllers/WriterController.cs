using BloggersWebSite.Areas.Admin.Models;
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

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writters.Add(w);
            var jsonwriters = JsonConvert.SerializeObject(w);
            return Json(jsonwriters);
        }

 
        public IActionResult DeleteWriter(int id)
        {
            var writer = writters.FirstOrDefault(y=>y.Id == id);
            writters.Remove(writer);
            return Json(writer);
        }

        public IActionResult UpdateWriter(WriterClass writerClass)
        {
            var writer = writters.FirstOrDefault(y => y.Id == writerClass.Id);

            if (writer != null)
            {
                writer.Name = writerClass.Name;
                var jsonWriter = JsonConvert.SerializeObject(writerClass);
                return Json(jsonWriter);
            }
            else
            {
                return NotFound(); // Eğer yazar bulunamazsa 404 hatası döndürülebilir.
            }
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
