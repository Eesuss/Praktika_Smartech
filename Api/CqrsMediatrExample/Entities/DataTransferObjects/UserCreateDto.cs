namespace Entities.DataTransferObjects
{
    public class UserCreateDto
    {
        public int IdPost { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string MiddleName { get; set; } = null!;
        public string? Password { get; set; } = null;
    }
}
