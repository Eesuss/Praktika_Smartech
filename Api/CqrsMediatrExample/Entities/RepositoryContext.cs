using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext() { }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public virtual DbSet<Course>? Courses { get; set; }
        public virtual DbSet<Journal>? journal { get; set; }
        public virtual DbSet<Lesson>? Lessons { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<StudentsJournal> StudentsJournals { get; set; }
        public virtual DbSet<UserJournal> UsersJournals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.HasOne(d => d.IdLessonNavigation).WithMany(p => p.Journals)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Journal_Lessons");

                entity.HasMany(d => d.IdStudents).WithMany(p => p.IdJournals)
                    .UsingEntity<Dictionary<string, object>>(
                        "StudentsJournal",
                        r => r.HasOne<Student>().WithMany()
                            .HasForeignKey("IdStudent")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_StudentsJournal_Students"),
                        l => l.HasOne<Journal>().WithMany()
                            .HasForeignKey("IdJournal")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_StudentsJournal_Journal"),
                        j =>
                        {
                            j.HasKey("IdJournal", "IdStudent");
                            j.ToTable("StudentsJournal");
                            j.IndexerProperty<int>("IdJournal").HasColumnName("ID_journal");
                            j.IndexerProperty<int>("IdStudent").HasColumnName("ID_student");
                        });
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasOne(d => d.IdCoursesNavigation).WithMany(p => p.Lessons)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lessons_Courses");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(d => d.UsersId);

                entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Users)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Post");

                entity.HasMany(d => d.IdJournals).WithMany(p => p.IdUsers)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserJournal",
                        r => r.HasOne<Journal>().WithMany()
                            .HasForeignKey("IdJournal")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_UserJournal_Journal"),
                        l => l.HasOne<User>().WithMany()
                            .HasForeignKey("IdUser")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_UserJournal_Users"),
                        j =>
                        {
                            j.HasKey("IdUser", "IdJournal").HasName("PK_UserJournal_1");
                            j.ToTable("UserJournal");
                            j.IndexerProperty<int>("IdUser").HasColumnName("ID_user");
                            j.IndexerProperty<int>("IdJournal").HasColumnName("ID_journal");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
