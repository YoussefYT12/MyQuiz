using MyQuiz.Dtos.QuizDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Contracts.IServices.IQuizService
{
    public interface IQuizServiceAsync
    {
        Task<IEnumerable<QuizGetDto>> GetAllOptionsAsync(QuizGetDto Obj);
        Task<QuizGetDto> GetByIdAsync(int id);
        Task<QuizGetDto> AddAsync(QuizAddDto Obj);
        Task<QuizGetDto> UpdateAsync( QuizUpdateDto Obj);
        Task<QuizGetDto> DeleteAsync(int id);
        
    }
}
