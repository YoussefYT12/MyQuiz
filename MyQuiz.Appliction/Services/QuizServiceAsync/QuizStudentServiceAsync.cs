using AutoMapper;
using MyQuiz.Appliction.Contracts.IRepositories.IQuiz;
using MyQuiz.Appliction.Contracts.IServices;
using MyQuiz.Appliction.Contracts.IServices.IQuizService;
using MyQuiz.Domain.Entities;
using MyQuiz.Dtos.QuizDto;
using MyQuiz.Dtos.QuizStudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Services.QuizServiceAsync
{
    public class QuizStudentServiceAsync : IQuizStudentServiceAsync
    {
        private readonly IQuizStudentRepositoryAsync quizStudentRepositoryAsync;
        private readonly IMapper mapper;

        public QuizStudentServiceAsync(IQuizStudentRepositoryAsync quizStudentRepositoryAsync, IMapper mapper)
        {
            this.quizStudentRepositoryAsync = quizStudentRepositoryAsync;
        }


        public async Task<QuizStudentGetDto> AddAsync(QuizStudentAddDto Obj)
        {
            var QuizStudenObj = mapper.Map<Tr_QuizStudent>(Obj);
            var QuizStudenObjAdded = await quizStudentRepositoryAsync.AddObjAsync(QuizStudenObj);
            var dataDto = mapper.Map<QuizStudentGetDto>(QuizStudenObjAdded);
            return dataDto;
        }

        public async Task<QuizStudentGetDto> DeleteAsync(int id)
        {
            var QuizStudenObj = await quizStudentRepositoryAsync.FindAsync(a => a.Id == id);

            var QuizStudenObjDeleted = await quizStudentRepositoryAsync.RemoveObjAsync(QuizStudenObj);

            var dataDto = mapper.Map<QuizStudentGetDto>(QuizStudenObjDeleted);

            return dataDto;
        }

        public async Task<IEnumerable<QuizStudentGetDto>> GetAllOptionsAsync()
        {
            var data = await quizStudentRepositoryAsync.GetAllAsync();
            var dataDto = mapper.Map<IEnumerable<QuizStudentGetDto>>(data);
            return dataDto;
        }

        public async Task<QuizStudentGetDto> GetByIdAsync(int id)
        {
            var data = await quizStudentRepositoryAsync.FindAsync(a => a.Id == id);
            var dataDto = mapper.Map<QuizStudentGetDto>(data);
            return dataDto;
        }

       
    }
}
