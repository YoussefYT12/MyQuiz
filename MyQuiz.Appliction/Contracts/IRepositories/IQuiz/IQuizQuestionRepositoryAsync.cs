using MyQuiz.Appliction.Contracts.IRepositories.IBaseRepositoryAsync;
using MyQuiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Contracts.IRepositories.IQuiz
{
    public interface IQuizQuestionRepositoryAsync : IBaseRepositoryAsync<Lk_QuizQuestion>
    {
    }
}
