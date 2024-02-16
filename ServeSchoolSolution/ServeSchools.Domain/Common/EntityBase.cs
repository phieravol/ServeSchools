namespace ServeSchools.Domain.Common
{
    public class EntityBase<T>
    {
        public required T Id { get; set; }
    }
}
