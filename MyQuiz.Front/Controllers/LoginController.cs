using Microsoft.AspNetCore.Mvc;

namespace MyQuiz.Front.Controllers
{
    public class LoginController : BaseController
    {
        public IActionResult ChooseLoginPage()
        {
            return View();
        }
    }
}
