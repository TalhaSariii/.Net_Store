using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var users = _manager.AuthService.GetAllUsers();
            return View(users);
        }

        public IActionResult Create()
        {
            try
            {
                return View(new UserDtoForCreation()
                {
                    Roles = new HashSet<string>(_manager
                    .AuthService
                    .Roles
                    .Select(r => r.Name)
                    .ToList())
                });
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            try
            {
                var result = await _manager.AuthService.CreateUser(userDto);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "User creation failed. Please try again.");
                return View(userDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View(userDto);
            }
        }

        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            try
            {
                var user = await _manager.AuthService.GetOneUserForUpdate(id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            try
            {
                await _manager.AuthService.Update(userDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View(userDto);
            }
        }
    }
}
