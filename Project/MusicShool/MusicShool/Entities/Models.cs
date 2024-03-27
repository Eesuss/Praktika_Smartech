using System;
using System.Collections.Generic;

namespace MusicShool.Entities
{
    public class Models
    {

    }

    public class Course
    {
        public int CoursesId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }

    public class Journal
    {
        public int JournalId { get; set; }
        public int IdLesson { get; set; }
        public DateTime DateLesson { get; set; }
        public Lesson IdLessonNavigation { get; set; } = null;
        public ICollection<Student> IdStudents { get; set; } = new List<Student>();
        public ICollection<User> IdUsers { get; set; } = new List<User>();
    }

    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int IdCourses { get; set; }
        public Course IdCoursesNavigation { get; set; } = null;
        public ICollection<Journal> Journals { get; set; } = new List<Journal>();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string NamePost { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; } = null;
        public string FirstName { get; set; } = null;
        public string MiddleName { get; set; }
        public bool Course1 { get; set; }
        public bool Course2 { get; set; }
        public bool Course3 { get; set; }
        public string TelephoneNumber { get; set; } = null;
        public string Address { get; set; }
        public ICollection<Journal> IdJournals { get; set; } = new List<Journal>();
    }

    public class User
    {
        public int UsersId { get; set; }
        public int IdPost { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = null;
        public string Password { get; set; } = null;
        public Post IdPostNavigation { get; set; } = null;
        public ICollection<Journal> IdJournals { get; set; } = new List<Journal>();
    }
}
