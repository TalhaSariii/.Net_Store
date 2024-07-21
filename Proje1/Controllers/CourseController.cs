using Microsoft.AspNetCore.Mvc;

namespace Proje1.Controllers
{
    public class CourseController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Apply()
        {
            return View();
        }

    }
}