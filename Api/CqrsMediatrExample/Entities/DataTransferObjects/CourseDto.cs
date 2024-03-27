using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class CourseDto
    {
        public int CoursesId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
