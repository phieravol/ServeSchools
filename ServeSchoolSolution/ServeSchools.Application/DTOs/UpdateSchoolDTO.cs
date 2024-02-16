namespace ServeSchools.Application.DTOs
{
    public class UpdateSchoolDTO
    {
        public required int Id {  get; set; }
        public required string Name { get; set; }
        public required DateTime FoundingDate { get; set; }
    }
}
