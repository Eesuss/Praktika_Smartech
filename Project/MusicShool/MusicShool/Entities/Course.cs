using System.Collections.Generic;

namespace MusicShool.Entities
{
    public class Course
    {
        public int CoursesId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
