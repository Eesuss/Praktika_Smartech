using System;
using System.Collections.Generic;

namespace MusicShool.Entities
{
    public class Journal
    {
        public int JournalId { get; set; }
        public int IdLesson { get; set; }
        public DateTime DateLesson { get; set; }
        public Lesson IdLessonNavigation { get; set; } = null;
        public ICollection<Student> IdStudents { get; set; } = new List<Student>();
        public ICollection<User> IdUsers { get; set; } = new List<User>();
    }
}
