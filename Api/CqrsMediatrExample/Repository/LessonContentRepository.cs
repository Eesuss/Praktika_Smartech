using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class LessonContentRepository : RepositoryBase<LessonContent>, ILessonContentRepository
    {
        public LessonContentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public IEnumerable<LessonContent> GetAllLessonContent()
        {
            return FindAll().ToList();
        }
    }
}
