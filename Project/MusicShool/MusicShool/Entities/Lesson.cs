using System.Collections.Generic;

namespace MusicShool.Entities
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int IdCourses { get; set; }
        public Course IdCoursesNavigation { get; set; } = null;
        public ICollection<Journal> Journals { get; set; } = new List<Journal>();
    }
}
