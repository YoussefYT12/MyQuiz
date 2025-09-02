using AutoMapper;
using MyQuiz.Appliction.Contracts.IRepositories.IQuiz;
using MyQuiz.Appliction.Contracts.IServices.IQuizService;
using MyQuiz.Domain.Entities;
using MyQuiz.Dtos.QuestionDto;
using MyQuiz.Dtos.QuizDto;
using MyQuiz.Dtos.QuizQuestionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Services.QuizServiceAsync
{
    public class QuizQuestionServiceAsync : IQuizQuestionServiceAsync
    {
        private readonly IQuizQuestionRepositoryAsync quizQuestionRepositoryAsync;
        private readonly IChoiceServiceAsync choiceServiceAsync;
        private readonly IMapper mapper;

        public QuizQuestionServiceAsync(IChoiceServiceAsync choiceServiceAsync,IQuizQuestionRepositoryAsync quizQuestionRepositoryAsync, IMapper mapper)
        {
            this.quizQuestionRepositoryAsync = quizQuestionRepositoryAsync;
            this.mapper = mapper;
            this.choiceServiceAsync = choiceServiceAsync;
        }


        public async Task<QuizQuestionGetDto> AddAsync(QuizQuestionAddDto Obj)
        {
            var QuizQuestionObj = mapper.Map<Lk_QuizQuestion>(Obj);
            var QuizQuestionObjAdded = await quizQuestionRepositoryAsync.AddObjAsync(QuizQuestionObj);

            foreach (var item in Obj.ChoiceAdds)
            {

                var choicesObjAdded = await choiceServiceAsync.AddAsync(item);
            }


            var dataDto = mapper.Map<QuizQuestionGetDto>(QuizQuestionObjAdded);
            return dataDto;
        }

        public async Task<QuizQuestionGetDto> DeleteAsync(int id)
        {
            var QuizQuestionObj = await quizQuestionRepositoryAsync.FindAsync(a => a.Id == id);

            var QuizQuestionObjDeleted = await quizQuestionRepositoryAsync.RemoveObjAsync(QuizQuestionObj);

            var dataDto = mapper.Map<QuizQuestionGetDto>(QuizQuestionObjDeleted);

            return dataDto;
        }

        public async Task<IEnumerable<QuizQuestionGetDto>> GetAllOptionsAsync(QuizQuestionGetDto Obj)
        {
            var data = await quizQuestionRepositoryAsync.GetAllAsync();

            foreach (var item in Obj.ChoiceGets)
            {

                var choiceObjGets = await choiceServiceAsync.GetByIdAsync(item.Id);
            }

            var dataDto = mapper.Map<IEnumerable<QuizQuestionGetDto>>(data);
            return dataDto;
        }

        public async Task<QuizQuestionGetDto> GetByIdAsync(int id)
        {
            var data = await quizQuestionRepositoryAsync.FindAsync(a => a.Id == id);
            var dataDto = mapper.Map<QuizQuestionGetDto>(data);
            return dataDto;
        }

       

        public async Task<QuizQuestionGetDto> UpdateAsync(QuizQuestionUpdateDto Obj)
        {
            var data = mapper.Map<Lk_QuizQuestion>(Obj);
            var dataUpdated = await quizQuestionRepositoryAsync.UpdateAsync(data);

            foreach (var item in Obj.ChoiceUpdeats)
            {

                var choiceObjUpdate = await choiceServiceAsync.UpdateAsync(item);
            }

            var dataDto = mapper.Map<QuizQuestionGetDto>(dataUpdated);
            return dataDto;
        }
    }
}
