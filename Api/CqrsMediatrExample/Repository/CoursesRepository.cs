using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CoursesRepository : RepositoryBase<Course>, ICoursesRepository
    {
        public CoursesRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public IEnumerable<Course> GetAllCourses()
        {
            return FindAll().Include(c => c.Lessons).ToList();
        }
    }
}
