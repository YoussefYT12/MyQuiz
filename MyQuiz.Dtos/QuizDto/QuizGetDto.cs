using MyQuiz.Dtos.QuizQuestionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Dtos.QuizDto
{
    public class QuizGetDto
    {
        public int Id { get; set; }
        public string QuizName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int DurationMinutes { get; set; }
        public List<QuizQuestionGetDto> QuizQuestionGets { get; set; }
    }
}
