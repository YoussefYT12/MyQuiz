using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyQuiz.Appliction.Contracts.IServices.IQuizService;
using MyQuiz.Domain.Entities;
using MyQuiz.Dtos.QuestionChoiceDto;
using MyQuiz.Dtos.QuizDto;
using MyQuiz.Infrastructure.AllContexts;

namespace MyQuiz.Api.Controllers.Quiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        
       private readonly IChoiceServiceAsync questionChoiceServiceAsync;

        public ChoiceController(IChoiceServiceAsync questionChoiceServiceAsync)
        {
            questionChoiceServiceAsync = questionChoiceServiceAsync;
        }

        
        [HttpGet]
        public async Task<ChoiceGetDto> GetById(int id)
        {
            var data = await questionChoiceServiceAsync.GetByIdAsync(id);
            return data;
        }

        #region
        //[HttpGet("{id}")]
        //public async Task<QuestionChoiceGetDto> GetById(int id)
        //{
        //    var data = await questionChoiceServiceAsync.Choices.FindAsync(id);
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }
        //    return data;
        //}

        // POST: api/QuizChoose
        #endregion


        //Add
        [HttpPost]
        public async Task<ChoiceGetDto> AddObj(ChoiceAddDto Obj)
        {
            var data = await questionChoiceServiceAsync.AddAsync(Obj);
            return data;
        }

        //Update
        [HttpPut]
        public async Task<ChoiceGetDto> UpdateObj(ChoiceUpdeatDto Obj)
        {

            var data = await questionChoiceServiceAsync.UpdateAsync(Obj);

            return data;

        }

       
        [HttpDelete]
        public async Task<ChoiceGetDto> Delete(int id)
        {
            var data = await questionChoiceServiceAsync.DeleteAsync(id);

            return data;
        }
    }
}

