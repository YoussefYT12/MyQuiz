using MyQuiz.Dtos.QuestionDto;
using MyQuiz.Dtos.QuizQuestionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Contracts.IServices.IQuizService
{
    public interface IQuizQuestionServiceAsync
    {
        Task<IEnumerable<QuizQuestionGetDto>> GetAllOptionsAsync(QuizQuestionGetDto Obj);
        Task<QuizQuestionGetDto> GetByIdAsync(int id);
        Task<QuizQuestionGetDto> AddAsync(QuizQuestionAddDto Obj);
        Task<QuizQuestionGetDto> UpdateAsync( QuizQuestionUpdateDto Obj);
        Task<QuizQuestionGetDto> DeleteAsync(int id);
        
        
    }
}
