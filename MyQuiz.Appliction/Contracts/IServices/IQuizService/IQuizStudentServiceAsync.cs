using MyQuiz.Domain.Entities;
using MyQuiz.Dtos.QuizStudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Contracts.IServices
{
    public interface IQuizStudentServiceAsync
    {
        Task<IEnumerable<QuizStudentGetDto>> GetAllOptionsAsync();
        Task<QuizStudentGetDto> GetByIdAsync(int id);
        Task<QuizStudentGetDto> AddAsync(QuizStudentAddDto Obj);
        Task<QuizStudentGetDto> DeleteAsync(int id);

        //Task AddObjAsync(Tr_QuizStudent quizStudentObj);

      //Task<QuizStudentGetDto> UpdateAsync(QuizStudentAddDto Obj);

    }
}
