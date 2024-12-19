
using Gambl.Data;
using Gambl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gambl.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _dataContext;

        public LoginController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Login Page
        public IActionResult Index()
        {
            return View();
        }

        /*[HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email and password are required.";
                return View();
            }

            var user = await _dataContext.UserInfos
                .FirstOrDefaultAsync(u => u.UserEmail == email && u.Password == password);

            if (user != null)
            {
                return RedirectToAction("Dashboard"); // Replace with your actual dashboard or home page
            }

            ViewBag.Error = "Invalid email or password.";
            return View();
        }*/
        [HttpGet]
        public IActionResult Admission()
        {
            return View();
        }

        // Giriş Kontrolü Yapar
        [HttpPost]
        public async Task<IActionResult> Admission(UserInfo model)
        {
            if (string.IsNullOrEmpty(model.UserEmail) || string.IsNullOrEmpty(model.Password))
            {
                ViewBag.Error = "Please enter both email and password.";
                return View();
            }

            // Veritabanında kullanıcıyı kontrol et
            var user = await _dataContext.UserInfos
                .FirstOrDefaultAsync(u => u.UserEmail == model.UserEmail && u.Password == model.Password);

            if (user != null)
            {
                // Kullanıcı giriş başarılı, yönlendirme yap
                return RedirectToAction("Index", "Home"); // Ana sayfaya yönlendir
            }

            // Giriş başarısızsa hata mesajı göster
            ViewBag.Error = "Invalid email or password. Please try again.";
            return View();
        }


        // Sign Up Page
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

        // User List
        public async Task<IActionResult> Users()
        {
            return View(await _dataContext.UserInfos.ToListAsync());
        }

        // Edit User
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var user = await _dataContext.UserInfos.FindAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserInfo model)
        {
            if (id != model.UserId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(model);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dataContext.UserInfos.Any(e => e.UserId == model.UserId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction("Users");
            }
            return View(model);
        }

        // Delete User
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var user = await _dataContext.UserInfos.FindAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _dataContext.UserInfos.FindAsync(id);
            if (user != null)
            {
                _dataContext.UserInfos.Remove(user);
                await _dataContext.SaveChangesAsync();
            }

            return RedirectToAction("Users");
        }
    }
}
