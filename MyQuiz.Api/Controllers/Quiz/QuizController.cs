using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyQuiz.Appliction.Contracts.IServices.IQuizService;
using MyQuiz.Domain.Entities;
using MyQuiz.Dtos.QuizDto;
using MyQuiz.Infrastructure.AllContexts;

namespace MyQuiz.Api.Controllers.Quiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizServiceAsync quizServiceAsync;

        public QuizController(IQuizServiceAsync quizServiceAsync)
        {
            this.quizServiceAsync = quizServiceAsync;
        }


        
        [HttpGet("{id}")]
        public async Task<QuizGetDto> GetById(int id)
        {
            var data = await quizServiceAsync.GetByIdAsync(id);

            return data;
        }

        // Add 
        [HttpPost]
        public async Task<QuizGetDto> AddObj(QuizAddDto Obj)
        {
            var data = await quizServiceAsync.AddAsync(Obj);
            return data;
        }

        //Update
        [HttpPut]
        public async Task<QuizGetDto> UpdateObj(QuizUpdateDto obj)
        {
            var data = await quizServiceAsync.UpdateAsync(obj);

            return data;
        }


        
        [HttpDelete("{id}")]
        public async Task<QuizGetDto> DeleteObj(int id)
        {
            var data = await quizServiceAsync.DeleteAsync(id);

            return data;
        }
    }
}

