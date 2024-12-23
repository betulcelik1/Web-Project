
using Gambl.Data;
using Gambl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Gambl.Controllers
{
        public class LoginController : Controller
        {
        private readonly DataContext _dataContext;

        public LoginController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Admission()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Admission(UserInfo model)
        {
        if (string.IsNullOrEmpty(model.UserEmail) || string.IsNullOrEmpty(model.Password))
        {
        ViewBag.Error = "Please enter both email and password.";
        return View();
        }

        var user = await _dataContext.UserInfos
        .FirstOrDefaultAsync(u => u.UserEmail == model.UserEmail && u.Password == model.Password);

        if (user != null)
        {
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserEmail ?? string.Empty)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

        return RedirectToAction("MyAccount", "Home");
        }

            ViewBag.Error = "Invalid email or password. Please try again.";
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserInfo model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _dataContext.UserInfos
                    .FirstOrDefaultAsync(u => u.UserEmail == model.UserEmail);

                if (existingUser != null)
                {
                    ModelState.AddModelError("UserEmail", "This email is already registered.");
                    return View(model);
                }

                _dataContext.UserInfos.Add(model);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Admission");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); // Ana sayfaya yönlendir
        }
    }
}
