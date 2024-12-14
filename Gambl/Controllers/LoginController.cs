using Gambl.Data;
using Gambl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Gambl.Controllers
{
    public class LoginController:Controller{
        private readonly DataContext _dataContext;
        public LoginController(DataContext datacontext){
            _dataContext=datacontext;
        }
        public async Task<IActionResult> Index(){

            return View(await _dataContext.UserInfos.ToListAsync());
        }
        public IActionResult Admission(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Admission(UserInfo model){
            _dataContext.UserInfos.Add(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Admission");
        }
        public IActionResult SignUp(){
            return View();
        }
        //Düzeleme kısmı
        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id==null){
                return NotFound();
            }
            var user= await _dataContext.UserInfos.FindAsync(id);
            if(user==null){
                                return NotFound();

            }
            return View(user);
        }
        [HttpPost]
        //güvenlik önlemi
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,UserInfo model){
            if(id!=model.UserId){
                return NotFound();

            }
            //güncelleme yapıyoruz database üzerinden
            if(ModelState.IsValid){
                try
                {
                    _dataContext.Update(model);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //KAYDIN VERİTABININDA OLUP OLMADIĞINA BAKIYORUZ
                    if(!_dataContext.UserInfos.Any(o=>o.UserId==model.UserId)){
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
    //silme işlemi
    [HttpGet]
    public async Task<IActionResult> Delete(int? id){
         if (id ==null)
    {
        return NotFound();
    }
    var user= await _dataContext.UserInfos.FindAsync(id);
    if(user==null){
        return NotFound();
    }
    return View(user);
    }
    [HttpPost]
    public async Task<IActionResult> Delete( [FromForm] int id){
     var user =await _dataContext.UserInfos.FindAsync(id);
     if(user==null){
        return NotFound();
     }
     _dataContext.UserInfos.Remove(user);
     await _dataContext.SaveChangesAsync();
     return RedirectToAction("Index");
    }

   



    }
}