using MyQuiz.Dtos.QuestionChoiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Dtos.QuizQuestionDto
{
    public class QuizQuestionUpdateDto
    {
        public int QuizId { get; set; }
        public List<ChoiceUpdeatDto> ChoiceUpdeats { get; set; }
    }
}
