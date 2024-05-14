using System.Collections.Generic;

namespace MusicShool.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string NamePost { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
