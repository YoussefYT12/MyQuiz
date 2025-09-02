using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Domain.Common
{
    public class EntityBase<T>
    {
        public T Id { get; set; }
    }
}
