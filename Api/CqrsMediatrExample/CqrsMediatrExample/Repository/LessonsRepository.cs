using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class LessonsRepository : RepositoryBase<Lesson>, IlessonsRepository
    {
        public LessonsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public IEnumerable<Lesson> GetAllLessons()
        {
            return FindAll().Include(l => l.IdCoursesNavigation).Include(l => l.Journals).OrderBy(les => les.LessonId).ToList();
        }
    }
}
