using Microsoft.AspNetCore.Mvc;

namespace MyQuiz.Front.Controllers
{
    public class ChatController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
