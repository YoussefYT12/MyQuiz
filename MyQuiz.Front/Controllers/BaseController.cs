using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyQuiz.Front.Controllers
{
    public class BaseController : Controller
    {
        protected readonly HttpClient _httpClient;

        public HttpClient client = new HttpClient();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            client.BaseAddress = new Uri("http://localhost:5038/");
            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            var baseAddress = config["ApiSettings:BaseAddress"];
            client.BaseAddress = new Uri(baseAddress);

            base.OnActionExecuting(context);
        }
    }
}
