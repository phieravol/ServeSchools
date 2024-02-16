namespace ServeSchools.Domain.Common
{
    public class Result
    {
        public required bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
