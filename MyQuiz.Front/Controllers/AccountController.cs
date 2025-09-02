using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyQuiz.Dtos;
using MyQuiz.Front.Models;

namespace MyQuiz.Front.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(UserLoginAdmin obj)

        {
            
            {
                
                if (obj.AdminName == "Youssef" && obj.Password == 0987654321)
                {
                    HttpContext.Session.SetString("username", obj.AdminName);
                    TempData["Youssef"] = "Yor are Logged in";
                    return RedirectToAction("Index", "Register");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect UserName Or Passward ");
                }
            }

            return View(obj);




        }
    }
}
