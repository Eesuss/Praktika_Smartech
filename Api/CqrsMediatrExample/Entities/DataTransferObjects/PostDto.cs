using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string? NamePost { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
