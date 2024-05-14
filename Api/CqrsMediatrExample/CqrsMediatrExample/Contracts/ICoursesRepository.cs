using Entities.Models;

namespace Contracts
{
    public interface ICoursesRepository : IRepositoryBase<Course>
    {
        IEnumerable<Course> GetAllCourses();
    }
}
