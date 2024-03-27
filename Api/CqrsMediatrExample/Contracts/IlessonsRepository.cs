using Entities.Models;

namespace Contracts
{
    public interface IlessonsRepository : IRepositoryBase<Lesson>
    {
        IEnumerable<Lesson> GetAllLessons();
    }
}
