using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Users")]
    public partial class User
    {
        [Key]
        [Column("Users_ID")]
        public int UsersId { get; set; }

        [Column("ID_post")]
        public int IdPost { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; } = null!;
        [StringLength(50)]
        public string? Password { get; set; } = null;

        [ForeignKey("IdPost")]
        [InverseProperty("Users")]
        public Post? IdPostNavigation { get; set; } = null!;

        [ForeignKey("IdUser")]
        [InverseProperty("IdUsers")]
        public ICollection<Journal>? IdJournals { get; set; } = null!;
    }
}
