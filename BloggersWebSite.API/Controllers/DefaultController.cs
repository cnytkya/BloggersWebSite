using BloggersWebSite.API.DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BloggersWebSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult EmployeeCreate(Employee employee)
        {
            using var c = new Context();
            c.Employees.Add(employee);
            c.SaveChanges();
            return Ok();
        }

        
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            } 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Employee updatedEmployee)
        {
            using var c = new Context();
            var emp = c.Find<Employee>(updatedEmployee.Id);

            if (emp != null)
            {
                emp.Name = updatedEmployee.Name;
                c.Update(emp);
                c.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Employees.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
        }


    }
}
