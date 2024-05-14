using Entities.Models;

namespace Entities.DataTransferObjects
{
    public partial class LessonContentDto
    {
        public int LessonContentID { get; set; }
        public int IdLesson { get; set; }
        public string? TypeContent { get; set; }
        public string? Content { get; set; }
        public Lesson? IdTypeContentNavigation { get; set; } = null;
    }
}
