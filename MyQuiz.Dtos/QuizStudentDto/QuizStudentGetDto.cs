using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Dtos.QuizStudentDto
{
    public class QuizStudentGetDto
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string UserId { get; set; }
    }
}
