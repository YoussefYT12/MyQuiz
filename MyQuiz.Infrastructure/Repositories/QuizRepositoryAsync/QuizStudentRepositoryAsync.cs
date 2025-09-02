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
    public class QuizStudentRepositoryAsync : BaseRepositoryAsync<Tr_QuizStudent>, IQuizStudentRepositoryAsync
    {
        public QuizStudentRepositoryAsync(QuizDemoAppContext context) : base(context) 
        {
        
        }
    }
}
