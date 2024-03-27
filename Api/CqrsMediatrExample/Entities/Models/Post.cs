using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Post
    {
        [Key]
        [Column("Post_ID")]
        public int PostId { get; set; }

        [Column("Name_post")]
        [StringLength(50)]
        public string? NamePost { get; set; }

        [InverseProperty("IdPostNavigation")]
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}


//[Key]
//public int Post_ID { get; set; }
//public string Name_Post { get; set; }
//public ICollection<Users> users { get; set; }