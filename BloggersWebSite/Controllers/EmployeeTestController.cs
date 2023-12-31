using BloggersWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BloggersWebSite.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClinet = new HttpClient();
            var responseMessage = await httpClinet.GetAsync("https://localhost:44356/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(employees);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 class1)
        {
            var httpClient = new HttpClient(); //önce HttpClient bir değer alıyoruz.
            var jsonEmployee = JsonConvert.SerializeObject(class1);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44356/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(class1);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44356/api/Default/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonEmp = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmp);
                return View(values);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 class1)
        {
            var httpClient = new HttpClient();
            var jsonEmp = JsonConvert.SerializeObject(class1);
            var content = new StringContent(jsonEmp, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44356/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(class1);
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44356/api/Default/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
            
        }

    }
}
