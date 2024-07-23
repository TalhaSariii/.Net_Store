using Microsoft.AspNetCore.Mvc;

using Proje1.Models; 

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
            [HttpPost]
            [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm] Candidate model)
        {
            Repository.Add(model);
            return View("Feedback",model);
        }

    }
}