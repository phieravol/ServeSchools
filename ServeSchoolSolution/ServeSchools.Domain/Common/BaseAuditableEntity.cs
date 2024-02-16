using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeSchools.Domain.Common
{
    public class BaseAuditableEntity<T>: EntityBase<T>
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }

    }
}
