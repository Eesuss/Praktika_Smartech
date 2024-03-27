using Entities.Models;

namespace Contracts
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        IEnumerable<Student> GetAllStudent();
    }
}
