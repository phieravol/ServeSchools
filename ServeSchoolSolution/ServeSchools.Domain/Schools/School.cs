using ServeSchools.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeSchools.Domain.Schools
{
    public class School : EntityBase<int>
    {
        public required string Name { get; set; }
        public required bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
