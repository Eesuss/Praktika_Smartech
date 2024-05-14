namespace Entities.Models
{
    public partial class UserJournal
    {

        public int IdUser { get; set; }
        public int IdJournal { get; set; }
        public int UserJournalId { get; set; }
        public virtual Journal IdJournalNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}


//[ForeignKey(nameof(user))]
//public int ID_user { get; set; }
//[ForeignKey(nameof(journal))]
//public int ID_journal { get; set; }
//[Key]
//public int UserJournal_ID { get; set; }
//public Users user { get; set; }
//public Journal journal { get; set; }