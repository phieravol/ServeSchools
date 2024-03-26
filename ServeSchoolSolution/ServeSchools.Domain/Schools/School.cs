using ServeSchools.Domain.Common;

namespace ServeSchools.Domain.Schools
{
    public class School : BaseAuditableEntity<int>, ISoftDeletable, IEntityBase<int>
    {
        public required string Name { get; set; }
        public required DateTime FoundingDate { get; set; }
        public bool IsDeleted { get ; set; }
    }
}
