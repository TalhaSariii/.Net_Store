using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class EmployeeController : Controller
    {
        public ViewResult Index1()
        {
            return View();
        }

        public ViewResult Index2()
        {
            return View("Index");
        }

        public IActionResult Index3()
        {
            var list=new List<Employee>()
            {
              new Employee(){Id=1, FirstName="Ahmet",LastName="Can",Age=20},
              new Employee(){Id=2, FirstName="TALHA",LastName="Can",Age=20},
              new Employee(){Id=3, FirstName="Veli",LastName="Can",Age=25},

            };
            return View ("Index3",list);
        }
    }
}