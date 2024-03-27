using Contracts;
using Entities;
using Entities.Models;
using System.Data.Entity;

namespace Repository
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
        }

        public IEnumerable<Post> GetAllPost()
        {
            return FindAll().Include(p => p.Users).ToList();
        }

        public Post GetPostAdmin(int id)
        {
            return FindByCondition(pst => pst.PostId.Equals(id)).Include(us => us.Users).FirstOrDefault();
        }
    }
}
