using MyQuiz.Dtos.QuestionChoiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Dtos.QuizQuestionDto
{
    public class QuizQuestionGetDto
    {
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public List<ChoiceGetDto> ChoiceGets { get; set; }
    }
}
