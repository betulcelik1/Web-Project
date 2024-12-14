using Gambl.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gambl.Models;
namespace Gambl.Controllers
{
    public class HomeController:Controller{
        private readonly DataContext _dataContext;
        public  HomeController (DataContext dataContext){
            _dataContext=dataContext;
        }
        
        public async Task<IActionResult> Index(){
            return View(await _dataContext.CourseInfos.ToListAsync());
        }
        public async Task<IActionResult> UserList(){
            return View(await _dataContext.UserInfos.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> MyAccount(int? id){
            if(id==null){
                return NotFound();
            }
            var user =await _dataContext.UserInfos.FindAsync(id);
            var _course =await _dataContext.CourseInfos.ToListAsync();
            if(user==null){
                return NotFound();
            }
            return View(_course);
        }
        public async Task<IActionResult> InstructorList(){
            return View(await _dataContext.InstructorInfos.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Instructor(int? id){
            if(id==null){
                return NotFound();
            }
            var instructor =await _dataContext.InstructorInfos.FindAsync(id);
            if(instructor==null){
                return NotFound();
            }
            return View(instructor);
        }
        public IActionResult GetCourseImage(int id)
{
    var course = _dataContext.CourseInfos.Find(id);
    if (course == null || course.CourseImage == null)
    {
        // Resim bulunamadığında bir placeholder göstermek
        return File("~/images/default-placeholder.jpg", "image/jpeg");
    }
    return File(course.CourseImage, "image/jpeg");
}


    }
}