using AutoMapper;
using MyQuiz.Appliction.Contracts.IRepositories.IQuiz;
using MyQuiz.Appliction.Contracts.IServices.IQuizService;
using MyQuiz.Domain.Entities;
using MyQuiz.Dtos.QuizDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Services.QuizServiceAsync
{
    public class QuizServiceAsync : IQuizServiceAsync
    {

        private readonly IQuizRepositoryAsync quizRepositoryAsync;
        private readonly IQuizQuestionServiceAsync quizQuestionServiceAsync;
        private readonly IMapper mapper;

        public QuizServiceAsync(IQuizQuestionServiceAsync quizQuestionServiceAsync,IQuizRepositoryAsync quizRepository, IMapper mapper)
        {
            this.quizRepositoryAsync = quizRepository;
            this.mapper = mapper;
            this.quizQuestionServiceAsync = quizQuestionServiceAsync;
        }


        public async Task<QuizGetDto> AddAsync(QuizAddDto Obj)
        {
            var QuizObj = mapper.Map<Lk_Quiz>(Obj);
            var QuizObjAdded = await quizRepositoryAsync.AddObjAsync(QuizObj);

            foreach (var item in Obj.QuizQuestionAdds)
            {

                var QuizQuestionObjAdded = await quizQuestionServiceAsync.AddAsync(item);
            }

            var dataDto = mapper.Map<QuizGetDto>(QuizObjAdded);
            return dataDto;
        }

        public async Task<QuizGetDto> DeleteAsync(int id)
        {
            var QuizObj = await quizRepositoryAsync.FindAsync(a => a.Id == id);

            var QuizObjDeleted = await quizRepositoryAsync.RemoveObjAsync(QuizObj);

            var dataDto = mapper.Map<QuizGetDto>(QuizObjDeleted);

            return dataDto;
        }

        public async Task<IEnumerable<QuizGetDto>> GetAllOptionsAsync(QuizGetDto Obj)
        {
            var data = await quizRepositoryAsync.GetAllAsync();

            foreach (var item in Obj.QuizQuestionGets)
            {

                var QuizQuestionObjGets = await quizQuestionServiceAsync.GetByIdAsync(item.QuestionId);
            }

            var dataDto = mapper.Map<IEnumerable<QuizGetDto>>(data);
            return dataDto;
        }

        public async Task<QuizGetDto> GetByIdAsync(int id)
        {
            var data = await quizRepositoryAsync.FindAsync(a => a.Id == id);
            var dataDto = mapper.Map<QuizGetDto>(data);
            return dataDto;
        }

        public async Task<QuizGetDto> UpdateAsync( QuizUpdateDto Obj)
        {
            var data = mapper.Map<Lk_Quiz>(Obj);
            var dataUpdated = await quizRepositoryAsync.UpdateAsync(data);

            foreach (var item in Obj.QuizQuestionUpdates)
            {

                var QuizQuestionObjUpdates = await quizQuestionServiceAsync.UpdateAsync(item);
            }

            var dataDto = mapper.Map<QuizGetDto>(dataUpdated);
            return dataDto;
        }

      
        
    }
}
