using Microsoft.AspNetCore.Mvc;

namespace Gambl.Controllers
{
    public class UserController:Controller{
        public IActionResult Index(){
            return View();
        }
        public IActionResult InstructorInfo(){
            return View();
        }
        public IActionResult MyAccount(){
            return View();
        }

    }
}