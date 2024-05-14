using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Journal
    {
        [Key]
        [Column("Journal_ID")]
        public int JournalId { get; set; }

        [Column("ID_Lesson")]
        public int IdLesson { get; set; }

        [Column("Date_lesson", TypeName = "datetime")]
        public DateTime DateLesson { get; set; }

        [ForeignKey("IdLesson")]
        [InverseProperty("Journals")]
        public Lesson IdLessonNavigation { get; set; } = null!;

        [ForeignKey("IdJournal")]
        [InverseProperty("IdJournals")]
        public ICollection<Student> IdStudents { get; set; } = new List<Student>();

        [ForeignKey("IdJournal")]
        [InverseProperty("IdJournals")]
        public ICollection<User> IdUsers { get; set; } = new List<User>();
    }
}

