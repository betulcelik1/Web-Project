using Gambl.Data;
using Gambl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gambl.Controllers
{
    public class CreateCourseController:Controller{
        private readonly DataContext _context;
        public CreateCourseController(DataContext context)
        {
            _context=context;
        }
        public async Task<IActionResult> Index(){
            
            return View(await _context.CourseInfos.ToListAsync());
        }
        public IActionResult CreateCourse(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseInfo model){
            _context.CourseInfos.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id==null){
                return NotFound();
            }
            var course=await _context.CourseInfos.FindAsync(id);
            if(course==null){
                return NotFound();
            }
            return View(course);
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,CourseInfo model){
            if(id!=model.CourseId){
                return NotFound();
            }
            if(ModelState.IsValid){
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!_context.CourseInfos.Any(o=>o.CourseId==model.CourseId)){
                        return NotFound();
                    }
                    else{
                        throw;

                    }
                
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
   
        [HttpGet]
        public async Task<IActionResult> Delete(int? id){
            if(id==null){
                return NotFound();
            }
            var course=await _context.CourseInfos.FindAsync(id);
            if(course==null){
                return NotFound();
            }
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Delete ([FromForm] int id){
            var course=await _context.CourseInfos.FindAsync(id);
            if(course==null){
                return NotFound();
            }
            _context.CourseInfos.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}