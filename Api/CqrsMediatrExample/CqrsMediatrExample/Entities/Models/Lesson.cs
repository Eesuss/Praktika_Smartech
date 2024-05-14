using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Lesson
    {
        [Key]
        [Column("Lesson_ID")]
        public int LessonId { get; set; }

        [Column("Lesson_name")]
        [StringLength(50)]
        public string? LessonName { get; set; }

        [Column("ID_courses")]
        public int IdCourses { get; set; }

        [ForeignKey("IdCourses")]
        [InverseProperty("Lessons")]
        public Course IdCoursesNavigation { get; set; } = null!;
        //public virtual Course IdCoursesNavigation { get; set; } = null!;

        [InverseProperty("IdLessonNavigation")]
        public ICollection<Journal> Journals { get; set; } = new List<Journal>();
        //public virtual ICollection<Journal> Journals { get; set; } = new List<Journal>();

        [InverseProperty("IdLessonContentNavigation")]
        public ICollection<LessonContent> IdlessonContents { get; set; } = new List<LessonContent>();


    }
}
