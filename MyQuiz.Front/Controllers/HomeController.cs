using Microsoft.AspNetCore.Mvc;

namespace MyQuiz.Front.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
