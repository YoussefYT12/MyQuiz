using MyQuiz.Dtos.QuestionChoiceDto;
using MyQuiz.Dtos.QuizDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Contracts.IServices.IQuizService
{
    public interface IChoiceServiceAsync
    {
        Task<ChoiceGetDto> GetByIdAsync(int Id);
        Task<ChoiceGetDto> AddAsync(ChoiceAddDto Obj);
        Task<ChoiceGetDto> DeleteAsync(int id);
        Task<ChoiceGetDto> UpdateAsync(ChoiceUpdeatDto Obj);
    }
}
