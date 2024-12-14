using Gambl.Data;
using Gambl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Gambl.Controllers
{
    public class CourseSignUpController:Controller{
        private readonly DataContext _context;
        public CourseSignUpController(DataContext context){
            _context=context;
        }
        
    }
    
}