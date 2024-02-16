using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeSchools.Domain.Base
{
    public class EntityBase<T>
    {
        public required T Id { get; set; }
    }
}
