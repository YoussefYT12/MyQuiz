using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyQuiz.Appliction.Contracts.IServices.IQuizService;
using MyQuiz.Dtos.QuestionDto;
using MyQuiz.Dtos.QuizDto;

namespace MyQuiz.Api.Controllers.Quiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionServiceAsync questionServiceAsync;

        public QuestionController(IQuestionServiceAsync questionServiceAsync)
        {
            this.questionServiceAsync = questionServiceAsync;
        }

        
        [HttpGet]
        public async Task<QuestionGetDto> GetById(int id)
        {
            var data = await questionServiceAsync.GetByIdAsync(id);

            return data;
        }

        // Add
        [HttpPost]
        public async Task<QuestionGetDto> AddObj(QuestionAddDto Obj)
        {
            var data = await questionServiceAsync.AddAsync(Obj);
            return data;
        }

        // Update
        [HttpPut]
        public async Task<QuestionGetDto> UpdateObj(QuestionUpdateDto Obj)
        {
            var data = await questionServiceAsync.UpdateAsync(Obj);

            return data;
        }

       
        [HttpDelete]
        public async Task<QuestionGetDto> DeleteObj(int id)
        {
            var data = await questionServiceAsync.DeleteAsync(id);

            return data;
        }
    }
}
