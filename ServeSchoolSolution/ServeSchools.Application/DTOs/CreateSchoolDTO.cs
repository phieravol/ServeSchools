namespace ServeSchools.Application.DTOs
{
    public class CreateSchoolDTO
    {
        public required string Name { get; set; }
        public required DateTime FoundingDate { get; set; }
    }
}
