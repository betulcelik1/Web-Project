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
            var course = await _context.CourseInfos.Include(c => c.Lessons).ThenInclude(l => l.content).FirstOrDefaultAsync(c => c.CourseId == id);
            return View(course);
        }

    }
}