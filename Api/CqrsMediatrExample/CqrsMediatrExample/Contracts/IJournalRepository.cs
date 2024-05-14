using Entities.Models;

namespace Contracts
{
    public interface IJournalRepository : IRepositoryBase<Journal>
    {
        IEnumerable<Journal> GetAllJournal();
    }
}
