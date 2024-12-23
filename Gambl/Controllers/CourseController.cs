using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gambl.Data;

namespace Gambl.Controllers
{
    public class CourseController:Controller{

        private readonly DataContext _context;
        public IActionResult Index(){
            return View();
        }

        public CourseController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CourseContent(int id)
        {
            var course = await _context.CourseInfos.Include(t => t.Lessons).ThenInclude(l => l.content).FirstOrDefaultAsync(t => t.CourseId == id);
            return View(course);
        }

        public IActionResult GetCourseImage(int id)
        {
            var course = _context.CourseInfos.Find(id);
            if (course == null || course.CourseImage == null)
            {
                // Resim bulunamadığında bir placeholder göstermek
                return File("~/images/default-placeholder.jpg", "image/jpeg");
            }
            return File(course.CourseImage, "image/jpeg");
        }

        public IActionResult GetInstructorImage(int id)
        {
            var course = _context.CourseInfos.Find(id);
            if (course==null){
                return File("~/images/default-placeholder.jpg", "image/jpeg");
            }
            var instructor = _context.InstructorInfos.Find(course.InstructorId);
            if(instructor == null || instructor.InstructorImage == null)
            {
                return File("~/images/default-placeholder.jpg", "image/jpeg");
            }
            return File(instructor.InstructorImage, "image/jpg");
        }
      
    }
    
}