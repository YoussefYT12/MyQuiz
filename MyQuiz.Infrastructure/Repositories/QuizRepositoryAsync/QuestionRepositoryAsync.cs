using MyQuiz.Appliction.Contracts.IRepositories.IQuiz;
using MyQuiz.Domain.Entities;
using MyQuiz.Infrastructure.AllContexts;
using MyQuiz.Infrastructure.Repositories.BaseRepositoryAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Infrastructure.Repositories.QuizRepositoryAsync
{
    public class QuestionRepositoryAsync : BaseRepositoryAsync<Lk_Question>, IQuestionRepositoryAsync
    {
        public QuestionRepositoryAsync(QuizDemoAppContext context) : base(context) 
        {
        
        }
    }
}
