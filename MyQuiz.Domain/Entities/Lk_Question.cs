using MyQuiz.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Domain.Entities
{
    public class Lk_Question : EntityBaseWithAudit<int>
    {
        public string QuestionName { get; set; }
        public int SysCodeQuestionTypeId { get; set; }
        public int SysCodeQuestionLevelId { get; set; }
        public int Points { get; set; }
    }
}
