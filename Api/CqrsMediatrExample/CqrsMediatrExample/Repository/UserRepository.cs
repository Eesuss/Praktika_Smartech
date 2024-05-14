using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public IEnumerable<User> GetAllUser()
        {
            return FindAll().Include(u => u.IdPostNavigation).Include(u => u.IdJournals).ToList();
        }

        public User GetByLogUser(string lstname, string pass)
        {
            return FindByCondition(us => us.LastName.Equals(lstname) && us.Password.Equals(pass)).FirstOrDefault();
        }

        public User GetUserById(int id) => FindByCondition(user => user.UsersId.Equals(id)).FirstOrDefault();

        public IEnumerable<User> GetAdminUsers()
        {
            return FindAll().Where(u => u.IdPost.Equals(1)).ToList();
        }

        public IEnumerable<User> GetTeacherUsers()
        {
            return FindAll().Where(u => u.IdPost.Equals(2)).ToList();
        }

        public void CreateUser(User user)
        {
            Create(user);
        }
    }
}
