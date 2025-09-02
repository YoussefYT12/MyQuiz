using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyQuiz.Appliction.Contracts.IServices.IQuizService;
using MyQuiz.Dtos.QuestionDto;
using MyQuiz.Dtos.QuizQuestionDto;

namespace MyQuiz.Api.Controllers.Quiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizQuestionController : ControllerBase
    {
        private readonly IQuizQuestionServiceAsync quizQuestionServiceAsync;

        public QuizQuestionController(IQuizQuestionServiceAsync quizQuestionServiceAsync)
        {
            this.quizQuestionServiceAsync = quizQuestionServiceAsync;
        }

        
        [HttpGet]
        public async Task<QuizQuestionGetDto> GetById(int id)
        {
            var data = await quizQuestionServiceAsync.GetByIdAsync(id);

            return data;
        }

        // Add
        [HttpPost]
        public async Task<QuizQuestionGetDto> AddObj(QuizQuestionAddDto Obj)
        {
            var data = await quizQuestionServiceAsync.AddAsync(Obj);
            return data;
        }

        // Update
        [HttpPut]
        public async Task<QuizQuestionGetDto> UpdateObj(QuizQuestionUpdateDto Obj)
        {
            var data = await quizQuestionServiceAsync.UpdateAsync(Obj);

            return data;
        }

        
        [HttpDelete]
        public async Task<QuizQuestionGetDto> DeleteObj(int id)
        {
            var data = await quizQuestionServiceAsync.DeleteAsync(id);

            return data;
        }
    }
}
