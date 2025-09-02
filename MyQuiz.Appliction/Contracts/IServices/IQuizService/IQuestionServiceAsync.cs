using MyQuiz.Dtos.QuestionChoiceDto;
using MyQuiz.Dtos.QuestionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Contracts.IServices.IQuizService
{
    public interface IQuestionServiceAsync
    {
        Task<IEnumerable<QuestionGetDto>> GetAllOptionsAsync(QuestionGetDto Obj);
        Task<QuestionGetDto> GetByIdAsync(int id);
        Task<QuestionGetDto> AddAsync(QuestionAddDto Obj);
        Task<QuestionGetDto> UpdateAsync(QuestionUpdateDto Obj);
        Task<QuestionGetDto> DeleteAsync(int id);

       
    }
}
