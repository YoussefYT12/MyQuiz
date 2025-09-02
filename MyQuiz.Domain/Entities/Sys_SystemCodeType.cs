using MyQuiz.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Domain.Entities
{
    public class Sys_SystemCodeType : EntityBase<int>
    {
        public string SystemCodeTypeName { get; set; }
        public string? SystemCodeTypeDescription { get; set; }
        public ICollection<Sys_SystemCode> SystemCodes { get; set; }
    }
}
