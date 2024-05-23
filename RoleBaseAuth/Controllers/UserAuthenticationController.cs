using Microsoft.AspNetCore.Mvc;
using RoleBaseAuth.Models.DTOs;
using RoleBaseAuth.Repositories.Services;

namespace RoleBaseAuth.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _userService;
        public UserAuthenticationController(IUserAuthenticationService userService)
        {
            _userService = userService;
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return View(registration);
            }
            registration.Role = "user";
            var result = await _userService.RegistrationAsync(registration);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var result = await _userService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("index", "Dashbord");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }
        //Admin 
        public async Task<IActionResult> AdminRegistration()
        {
            var model = new Registration
            {
                Username = "Admin",
                Name = "Rifat",
                Email = "rifat@gmail.com",
                Password = "Admin@1234",

            };
            model.Role = "admin";
            var result = await _userService.RegistrationAsync(model);

            return Ok(result);
        }


    }
}
