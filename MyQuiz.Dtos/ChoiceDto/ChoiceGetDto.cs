using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Dtos.QuestionChoiceDto
{
    public class ChoiceGetDto
    {
        public int Id { get; set; }
        public string ChoiceName { get; set; }
        public bool IsCorrect { get; set; }
    }
}
