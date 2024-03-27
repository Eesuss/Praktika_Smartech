using Entities.Models;

namespace Contracts
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        IEnumerable<Post> GetAllPost();

        Post GetPostAdmin(int postid);
    }
}
