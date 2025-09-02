using MyQuiz.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Domain.Entities
{
    public class Lk_Choice : EntityBase<int>
    {
        public string ChoisName { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
