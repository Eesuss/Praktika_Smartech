using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public bool? Course1 { get; set; }
        public bool? Course2 { get; set; }
        public bool? Course3 { get; set; }
        public string TelephoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public ICollection<Journal> IdJournals { get; set; } = new List<Journal>();
    }
}
