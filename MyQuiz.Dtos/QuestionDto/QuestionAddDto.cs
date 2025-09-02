using MyQuiz.Dtos.QuestionChoiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Dtos.QuestionDto
{
    public class QuestionAddDto
    {
        public string QuestionName { get; set; }
        public int SysCodeQuestionTypeId { get; set; }
        public int SysCodeQuestionLevelId { get; set; }
        public int Points { get; set; }
        public List<ChoiceAddDto> ChoiceAdds { get; set; }
    }
}
