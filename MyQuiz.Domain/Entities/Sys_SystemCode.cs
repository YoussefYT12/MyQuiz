using MyQuiz.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Domain.Entities
{
    public class Sys_SystemCode : EntityBase<int>
    {
        public string SystemCodeName { get; set; }
        public int SystemCodeTypeId { get; set; }
        public Sys_SystemCodeType SystemCodeType { get; set; }
    }
}
