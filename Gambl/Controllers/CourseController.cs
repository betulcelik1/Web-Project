using Microsoft.AspNetCore.Mvc;

namespace Gambl.Controllers
{
    public class CourseController:Controller{
        public IActionResult Index(){
            return View();
        }
        public IActionResult CourseContent(){
            return View();
        }

    }
}