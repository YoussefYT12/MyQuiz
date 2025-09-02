using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyQuiz.Appliction.Contracts.IServices;
using MyQuiz.Appliction.Contracts.IServices.IQuizService;
using MyQuiz.Dtos.QuestionDto;
using MyQuiz.Dtos.QuizStudentDto;

namespace MyQuiz.Api.Controllers.Quiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizStudentController : ControllerBase
    {
        private readonly IQuizStudentServiceAsync quizStudentServiceAsync;

        public QuizStudentController(IQuizStudentServiceAsync quizStudentServiceAsync)
        {
            this.quizStudentServiceAsync = quizStudentServiceAsync;
        }

        
        [HttpGet]
        public async Task<QuizStudentGetDto> GetById(int id)
        {
            var data = await quizStudentServiceAsync.GetByIdAsync(id);

            return data;
        }

        // Add
        [HttpPost]
        public async Task<QuizStudentGetDto> AddObj(QuizStudentAddDto Obj)
        {
            var data = await quizStudentServiceAsync.AddAsync(Obj);
            return data;
        }

       
        [HttpDelete]
        public async Task<QuizStudentGetDto> DeleteObj(int id)
        {
            var data = await quizStudentServiceAsync.DeleteAsync(id);

            return data;
        }

    }
}
