using AutoMapper;
using MyQuiz.Appliction.Contracts.IRepositories.IQuiz;
using MyQuiz.Appliction.Contracts.IServices.IQuizService;
using MyQuiz.Domain.Entities;
using MyQuiz.Dtos.QuestionChoiceDto;
using MyQuiz.Dtos.QuizDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Services.QuizServiceAsync
{
    public class QuestionChoiceServiceAsync : IChoiceServiceAsync
    {
        private readonly IQuestionChoiceRepositoryAsync questionChoiceRepositoryAsync;
        private readonly IMapper mapper;

        public QuestionChoiceServiceAsync(IQuestionChoiceRepositoryAsync questionChoiceRepositoryAsync, IMapper mapper)
        {
            this.questionChoiceRepositoryAsync = questionChoiceRepositoryAsync;
        }



        public async Task<ChoiceGetDto> AddAsync(ChoiceAddDto Obj)
        {
            var QuizObj = mapper.Map<Lk_Choice>(Obj);
            var QuizObjAdded = await questionChoiceRepositoryAsync.AddObjAsync(QuizObj);

            var dataDto = mapper.Map<ChoiceGetDto>(QuizObjAdded);
            return dataDto;
        }

        public async Task<ChoiceGetDto> DeleteAsync(int id)
        {
            var QuestionChoiceObj = await questionChoiceRepositoryAsync.FindAsync(a => a.Id == id);

            var QuestionChoiceObjDeleted = await questionChoiceRepositoryAsync.RemoveObjAsync(QuestionChoiceObj);

            var dataDto = mapper.Map<ChoiceGetDto>(QuestionChoiceObjDeleted);

            return dataDto;
        }

        public async Task<ChoiceGetDto> GetByIdAsync(int questionId)
        {
            var data = await questionChoiceRepositoryAsync.FindAsync(a => a.Id == questionId);
            var dataDto = mapper.Map<ChoiceGetDto>(data);
            return dataDto;
        }

        public async Task<ChoiceGetDto> UpdateAsync(ChoiceUpdeatDto Obj)
        {
            var data = mapper.Map<Lk_Choice>(Obj);
            var dataUpdated = await questionChoiceRepositoryAsync.UpdateAsync(data);
            var dataDto = mapper.Map<ChoiceGetDto>(dataUpdated);
            return dataDto;
        }
    }
}
