using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class JournalRepository : RepositoryBase<Journal>, IJournalRepository
    {
        public JournalRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Journal> GetAllJournal()
        {
            return FindAll().Include(j => j.IdStudents).OrderBy(journ => journ.JournalId).ToList();
        }
    }
}
