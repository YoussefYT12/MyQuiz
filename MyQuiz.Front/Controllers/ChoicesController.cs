using Microsoft.AspNetCore.Mvc;
using MyQuiz.Dtos.QuestionChoiceDto;
using System.Web;

namespace MyQuiz.Front.Controllers
{
    public class ChoicesController : BaseController
    {

        public IActionResult Get()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChoiceAddDto Obj)
        {
            if (ModelState.IsValid)
            {

                var response = await client.PostAsJsonAsync("/api/Choices/AddObj", Obj);
                return RedirectToAction("Index");
            }
            else
            {
                return View(Obj);
            }


        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var Choice = await client.GetFromJsonAsync<ChoiceGetDto>($"/api/Choices/GetById?id={id}");

            var updateModel = new ChoiceUpdeatDto
            {
                Id = Choice.Id,
                ChoiceName = Choice.ChoiceName
            };

            return View(updateModel);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ChoiceUpdeatDto Obj)
        {
            if (ModelState.IsValid)
            {
                var response = await client.PutAsJsonAsync("/api/Choices/UpdateObj", Obj);

                return RedirectToAction("Index");
            }
            else
            {
                return View(Obj);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await client.DeleteAsync($"/api/Choices/DeleteObj?id={id}");

            return RedirectToAction("Index");

        }
    }
}
