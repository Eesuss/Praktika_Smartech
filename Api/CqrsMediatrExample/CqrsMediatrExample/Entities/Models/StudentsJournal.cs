namespace Entities.Models
{
    public partial class StudentsJournal
    {

        public int StudentsJournalId { get; set; }

        public int IdStudent { get; set; }

        public int IdJournal { get; set; }

        public virtual Journal IdJournalNavigation { get; set; } = null!;
        public virtual Student IdStudentNavigation { get; set; } = null!;
    }
}
