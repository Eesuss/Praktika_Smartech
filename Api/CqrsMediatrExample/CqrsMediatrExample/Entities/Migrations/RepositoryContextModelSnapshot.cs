﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Course", b =>
                {
                    b.Property<int>("CoursesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Courses_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoursesId"));

                    b.Property<string>("CourseName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Course_name");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CoursesId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Entities.Models.Journal", b =>
                {
                    b.Property<int>("JournalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Journal_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JournalId"));

                    b.Property<DateTime>("DateLesson")
                        .HasColumnType("datetime")
                        .HasColumnName("Date_lesson");

                    b.Property<int>("IdLesson")
                        .HasColumnType("int")
                        .HasColumnName("ID_Lesson");

                    b.HasKey("JournalId");

                    b.HasIndex("IdLesson");

                    b.ToTable("journal");
                });

            modelBuilder.Entity("Entities.Models.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Lesson_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessonId"));

                    b.Property<int>("IdCourses")
                        .HasColumnType("int")
                        .HasColumnName("ID_courses");

                    b.Property<string>("LessonName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Lesson_name");

                    b.HasKey("LessonId");

                    b.HasIndex("IdCourses");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Entities.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Post_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<string>("NamePost")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name_post");

                    b.HasKey("PostId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Entities.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Student_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Address")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<bool?>("Course1")
                        .HasColumnType("bit")
                        .HasColumnName("Course_1");

                    b.Property<bool?>("Course2")
                        .HasColumnType("bit")
                        .HasColumnName("Course_2");

                    b.Property<bool?>("Course3")
                        .HasColumnType("bit")
                        .HasColumnName("Course_3");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Telephone_number");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Entities.Models.StudentsJournal", b =>
                {
                    b.Property<int>("StudentsJournalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentsJournalId"));

                    b.Property<int>("IdJournal")
                        .HasColumnType("int");

                    b.Property<int>("IdJournalNavigationJournalId")
                        .HasColumnType("int");

                    b.Property<int>("IdStudent")
                        .HasColumnType("int");

                    b.Property<int>("IdStudentNavigationStudentId")
                        .HasColumnType("int");

                    b.HasKey("StudentsJournalId");

                    b.HasIndex("IdJournalNavigationJournalId");

                    b.HasIndex("IdStudentNavigationStudentId");

                    b.ToTable("StudentsJournals");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Users_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsersId"));

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdPost")
                        .HasColumnType("int")
                        .HasColumnName("ID_post");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UsersId");

                    b.HasIndex("IdPost");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Models.UserJournal", b =>
                {
                    b.Property<int>("UserJournalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserJournalId"));

                    b.Property<int>("IdJournal")
                        .HasColumnType("int");

                    b.Property<int>("IdJournalNavigationJournalId")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdUserNavigationUsersId")
                        .HasColumnType("int");

                    b.HasKey("UserJournalId");

                    b.HasIndex("IdJournalNavigationJournalId");

                    b.HasIndex("IdUserNavigationUsersId");

                    b.ToTable("UsersJournals");
                });

            modelBuilder.Entity("JournalStudent", b =>
                {
                    b.Property<int>("IdJournal")
                        .HasColumnType("int");

                    b.Property<int>("IdStudent")
                        .HasColumnType("int");

                    b.HasKey("IdJournal", "IdStudent");

                    b.ToTable("JournalStudent");
                });

            modelBuilder.Entity("JournalUser", b =>
                {
                    b.Property<int>("IdJournal")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("IdJournal", "IdUser");

                    b.ToTable("JournalUser");
                });

            modelBuilder.Entity("StudentsJournal", b =>
                {
                    b.Property<int>("IdJournal")
                        .HasColumnType("int")
                        .HasColumnName("ID_journal");

                    b.Property<int>("IdStudent")
                        .HasColumnType("int")
                        .HasColumnName("ID_student");

                    b.HasKey("IdJournal", "IdStudent");

                    b.HasIndex("IdStudent");

                    b.ToTable("StudentsJournal", (string)null);
                });

            modelBuilder.Entity("UserJournal", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("ID_user");

                    b.Property<int>("IdJournal")
                        .HasColumnType("int")
                        .HasColumnName("ID_journal");

                    b.HasKey("IdUser", "IdJournal")
                        .HasName("PK_UserJournal_1");

                    b.HasIndex("IdJournal");

                    b.ToTable("UserJournal", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Journal", b =>
                {
                    b.HasOne("Entities.Models.Lesson", "IdLessonNavigation")
                        .WithMany("Journals")
                        .HasForeignKey("IdLesson")
                        .IsRequired()
                        .HasConstraintName("FK_Journal_Lessons");

                    b.Navigation("IdLessonNavigation");
                });

            modelBuilder.Entity("Entities.Models.Lesson", b =>
                {
                    b.HasOne("Entities.Models.Course", "IdCoursesNavigation")
                        .WithMany("Lessons")
                        .HasForeignKey("IdCourses")
                        .IsRequired()
                        .HasConstraintName("FK_Lessons_Courses");

                    b.Navigation("IdCoursesNavigation");
                });

            modelBuilder.Entity("Entities.Models.StudentsJournal", b =>
                {
                    b.HasOne("Entities.Models.Journal", "IdJournalNavigation")
                        .WithMany()
                        .HasForeignKey("IdJournalNavigationJournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Student", "IdStudentNavigation")
                        .WithMany()
                        .HasForeignKey("IdStudentNavigationStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdJournalNavigation");

                    b.Navigation("IdStudentNavigation");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.HasOne("Entities.Models.Post", "IdPostNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdPost")
                        .IsRequired()
                        .HasConstraintName("FK_Users_Post");

                    b.Navigation("IdPostNavigation");
                });

            modelBuilder.Entity("Entities.Models.UserJournal", b =>
                {
                    b.HasOne("Entities.Models.Journal", "IdJournalNavigation")
                        .WithMany()
                        .HasForeignKey("IdJournalNavigationJournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "IdUserNavigation")
                        .WithMany()
                        .HasForeignKey("IdUserNavigationUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdJournalNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("StudentsJournal", b =>
                {
                    b.HasOne("Entities.Models.Journal", null)
                        .WithMany()
                        .HasForeignKey("IdJournal")
                        .IsRequired()
                        .HasConstraintName("FK_StudentsJournal_Journal");

                    b.HasOne("Entities.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("IdStudent")
                        .IsRequired()
                        .HasConstraintName("FK_StudentsJournal_Students");
                });

            modelBuilder.Entity("UserJournal", b =>
                {
                    b.HasOne("Entities.Models.Journal", null)
                        .WithMany()
                        .HasForeignKey("IdJournal")
                        .IsRequired()
                        .HasConstraintName("FK_UserJournal_Journal");

                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_UserJournal_Users");
                });

            modelBuilder.Entity("Entities.Models.Course", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Entities.Models.Lesson", b =>
                {
                    b.Navigation("Journals");
                });

            modelBuilder.Entity("Entities.Models.Post", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
