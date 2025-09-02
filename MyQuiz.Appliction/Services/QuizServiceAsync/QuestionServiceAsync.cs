using AutoMapper;
using MyQuiz.Appliction.Contracts.IRepositories.IQuiz;
using MyQuiz.Appliction.Contracts.IServices.IQuizService;
using MyQuiz.Domain.Entities;
using MyQuiz.Dtos.QuestionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Services.QuizServiceAsync
{
    public class QuestionServiceAsync : IQuestionServiceAsync
    {

        private readonly IQuestionRepositoryAsync questionRepositoryAsync;
        private readonly IChoiceServiceAsync choiceServiceAsync;
        private readonly IMapper mapper;

        public QuestionServiceAsync(IChoiceServiceAsync choiceServiceAsync, IQuestionRepositoryAsync questionRepositoryAsync, IMapper mapper)
        {
            this.questionRepositoryAsync = questionRepositoryAsync;
            this.mapper = mapper;
            this.choiceServiceAsync = choiceServiceAsync;
        }


        public async Task<QuestionGetDto> AddAsync(QuestionAddDto Obj)
        {
            var QuestionObj = mapper.Map<Lk_Question>(Obj);
            var QuestionObjAdded = await questionRepositoryAsync.AddObjAsync(QuestionObj);


            foreach (var item in Obj.ChoiceAdds)
            {

                var choicesObjAdded = await choiceServiceAsync.AddAsync(item);
            }


            var dataDto = mapper.Map<QuestionGetDto>(QuestionObjAdded);
            return dataDto;
        }

        public async Task<QuestionGetDto> DeleteAsync(int id)
        {
            var QuestionObj = await questionRepositoryAsync.FindAsync(a => a.Id == id);

            var QuestionObjDeleted = await questionRepositoryAsync.RemoveObjAsync(QuestionObj);

            var dataDto = mapper.Map<QuestionGetDto>(QuestionObjDeleted);

            return dataDto;
        }

        public async Task<IEnumerable<QuestionGetDto>> GetAllOptionsAsync(QuestionGetDto Obj)
        {
            var data = await questionRepositoryAsync.GetAllAsync();


            foreach (var item in Obj.ChoiceGets)
            {
                var choiceObjGets = await choiceServiceAsync.GetByIdAsync(item.Id);
            }


            var dataDto = mapper.Map<IEnumerable<QuestionGetDto>>(data);
            return dataDto;
        }

        public async Task<QuestionGetDto> GetByIdAsync(int id)
        {
            var data = await questionRepositoryAsync.FindAsync(a => a.Id == id);
            var dataDto = mapper.Map<QuestionGetDto>(data);
            return dataDto;
        }

        public async Task<QuestionGetDto> UpdateAsync(QuestionUpdateDto Obj)
        {
            var data = mapper.Map<Lk_Question>(Obj);
            var dataUpdated = await questionRepositoryAsync.UpdateAsync(data);

            foreach (var item in Obj.ChoiceUpdeats)
            {
                var choiceObjUpdate = await choiceServiceAsync.UpdateAsync(item);
            }


            var dataDto = mapper.Map<QuestionGetDto>(dataUpdated);
            return dataDto;
        }
    }
}
