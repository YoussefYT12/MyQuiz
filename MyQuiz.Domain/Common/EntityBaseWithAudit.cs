using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Domain.Common
{
    public class EntityBaseWithAudit<T> : EntityBase<T>
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public Nullable<int> LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
