using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUser();
        User GetByLogUser(string lstname, string pass);
        User GetUserById(int userid);
        IEnumerable<User> GetAdminUsers();
        IEnumerable<User> GetTeacherUsers();
        void CreateUser(User user);
    }
}
