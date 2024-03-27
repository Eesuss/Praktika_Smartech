using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class LessonDto
    {
        public int LessonId { get; set; }
        public string? LessonName { get; set; }
        public int IdCourses { get; set; }
        public Course IdCoursesNavigation { get; set; } = null!;
        public ICollection<Journal> Journals { get; set; } = new List<Journal>();
    }
}
