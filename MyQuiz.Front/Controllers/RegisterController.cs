using Microsoft.AspNetCore.Mvc;
using MyQuiz.Dtos.UserDto;
using MyQuiz.Front.Models;

namespace MyQuiz.Front.Controllers
{
    public class RegisterController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LoginDto identityAdd)
        {
            if (ModelState.IsValid)
            {

                var response = await client.PostAsJsonAsync("/api/Identity/AddObj", identityAdd);

                ////؟؟؟؟
                return RedirectToAction("");
            }
            else
            {
                return View(identityAdd);
            }
        }
}   }

