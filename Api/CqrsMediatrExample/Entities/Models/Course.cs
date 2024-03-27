using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Course
    {
        [Key]
        [Column("Courses_ID")]
        public int CoursesId { get; set; }

        [Column("Course_name")]
        [StringLength(50)]
        public string? CourseName { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [InverseProperty("IdCoursesNavigation")]
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        //public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    }
}
