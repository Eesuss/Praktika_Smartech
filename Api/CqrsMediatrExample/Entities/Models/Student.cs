using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models;

[Table("Students")]
public partial class Student
{
    [Key]
    [Column("Student_ID")]
    public int StudentId { get; set; }

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string? MiddleName { get; set; }

    [Column("Course_1")]
    public bool? Course1 { get; set; }

    [Column("Course_2")]
    public bool? Course2 { get; set; }

    [Column("Course_3")]
    public bool? Course3 { get; set; }

    [Column("Telephone_number")]
    [StringLength(20)]
    public string TelephoneNumber { get; set; } = null!;

    [StringLength(80)]
    public string? Address { get; set; }

    [ForeignKey("IdStudent")]
    [InverseProperty("IdStudents")]
    public ICollection<Journal> IdJournals { get; set; } = new List<Journal>();

}

