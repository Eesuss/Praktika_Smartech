using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class LessonContent
    {
        [Key]
        [Column("LessonContent_ID")]
        public int LessonContentID { get; set; }

        [Column("ID_lesson")]
        public int IdLesson { get; set; }

        [Column("TypeContent")]
        public string? TypeContent { get; set; }

        [Column("[Content]")]
        public string? Content { get; set; }

        [ForeignKey("IdTypeContent")]
        [InverseProperty("LessonContent")]
        public Lesson? IdTypeContentNavigation { get; set; } = null;

    }
}
