using Entities.Models;

namespace Contracts
{
    public interface ILessonContentRepository : IRepositoryBase<LessonContent>
    {
        IEnumerable<LessonContent> GetAllLessonContent();
    }
}
