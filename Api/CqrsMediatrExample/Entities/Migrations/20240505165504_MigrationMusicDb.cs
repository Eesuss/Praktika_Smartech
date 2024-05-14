using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class MigrationMusicDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Courses_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Courses_ID);
                });

            migrationBuilder.CreateTable(
                name: "JournalStudent",
                columns: table => new
                {
                    IdJournal = table.Column<int>(type: "int", nullable: false),
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalStudent", x => new { x.IdJournal, x.IdStudent });
                });

            migrationBuilder.CreateTable(
                name: "JournalUser",
                columns: table => new
                {
                    IdJournal = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalUser", x => new { x.IdJournal, x.IdUser });
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Post_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_post = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Post_ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Course_1 = table.Column<bool>(type: "bit", nullable: true),
                    Course_2 = table.Column<bool>(type: "bit", nullable: true),
                    Course_3 = table.Column<bool>(type: "bit", nullable: true),
                    Telephone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_ID);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Lesson_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lesson_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ID_courses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Lesson_ID);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses",
                        column: x => x.ID_courses,
                        principalTable: "Courses",
                        principalColumn: "Courses_ID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Users_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_post = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Users_ID);
                    table.ForeignKey(
                        name: "FK_Users_Post",
                        column: x => x.ID_post,
                        principalTable: "Post",
                        principalColumn: "Post_ID");
                });

            migrationBuilder.CreateTable(
                name: "journal",
                columns: table => new
                {
                    Journal_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Lesson = table.Column<int>(type: "int", nullable: false),
                    Date_lesson = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_journal", x => x.Journal_ID);
                    table.ForeignKey(
                        name: "FK_Journal_Lessons",
                        column: x => x.ID_Lesson,
                        principalTable: "Lessons",
                        principalColumn: "Lesson_ID");
                });

            migrationBuilder.CreateTable(
                name: "StudentsJournal",
                columns: table => new
                {
                    ID_journal = table.Column<int>(type: "int", nullable: false),
                    ID_student = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsJournal", x => new { x.ID_journal, x.ID_student });
                    table.ForeignKey(
                        name: "FK_StudentsJournal_Journal",
                        column: x => x.ID_journal,
                        principalTable: "journal",
                        principalColumn: "Journal_ID");
                    table.ForeignKey(
                        name: "FK_StudentsJournal_Students",
                        column: x => x.ID_student,
                        principalTable: "Students",
                        principalColumn: "Student_ID");
                });

            migrationBuilder.CreateTable(
                name: "StudentsJournals",
                columns: table => new
                {
                    StudentsJournalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    IdJournal = table.Column<int>(type: "int", nullable: false),
                    IdJournalNavigationJournalId = table.Column<int>(type: "int", nullable: false),
                    IdStudentNavigationStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsJournals", x => x.StudentsJournalId);
                    table.ForeignKey(
                        name: "FK_StudentsJournals_Students_IdStudentNavigationStudentId",
                        column: x => x.IdStudentNavigationStudentId,
                        principalTable: "Students",
                        principalColumn: "Student_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsJournals_journal_IdJournalNavigationJournalId",
                        column: x => x.IdJournalNavigationJournalId,
                        principalTable: "journal",
                        principalColumn: "Journal_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJournal",
                columns: table => new
                {
                    ID_user = table.Column<int>(type: "int", nullable: false),
                    ID_journal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJournal_1", x => new { x.ID_user, x.ID_journal });
                    table.ForeignKey(
                        name: "FK_UserJournal_Journal",
                        column: x => x.ID_journal,
                        principalTable: "journal",
                        principalColumn: "Journal_ID");
                    table.ForeignKey(
                        name: "FK_UserJournal_Users",
                        column: x => x.ID_user,
                        principalTable: "Users",
                        principalColumn: "Users_ID");
                });

            migrationBuilder.CreateTable(
                name: "UsersJournals",
                columns: table => new
                {
                    UserJournalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdJournal = table.Column<int>(type: "int", nullable: false),
                    IdJournalNavigationJournalId = table.Column<int>(type: "int", nullable: false),
                    IdUserNavigationUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersJournals", x => x.UserJournalId);
                    table.ForeignKey(
                        name: "FK_UsersJournals_Users_IdUserNavigationUsersId",
                        column: x => x.IdUserNavigationUsersId,
                        principalTable: "Users",
                        principalColumn: "Users_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersJournals_journal_IdJournalNavigationJournalId",
                        column: x => x.IdJournalNavigationJournalId,
                        principalTable: "journal",
                        principalColumn: "Journal_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_journal_ID_Lesson",
                table: "journal",
                column: "ID_Lesson");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ID_courses",
                table: "Lessons",
                column: "ID_courses");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsJournal_ID_student",
                table: "StudentsJournal",
                column: "ID_student");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsJournals_IdJournalNavigationJournalId",
                table: "StudentsJournals",
                column: "IdJournalNavigationJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsJournals_IdStudentNavigationStudentId",
                table: "StudentsJournals",
                column: "IdStudentNavigationStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJournal_ID_journal",
                table: "UserJournal",
                column: "ID_journal");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ID_post",
                table: "Users",
                column: "ID_post");

            migrationBuilder.CreateIndex(
                name: "IX_UsersJournals_IdJournalNavigationJournalId",
                table: "UsersJournals",
                column: "IdJournalNavigationJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersJournals_IdUserNavigationUsersId",
                table: "UsersJournals",
                column: "IdUserNavigationUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalStudent");

            migrationBuilder.DropTable(
                name: "JournalUser");

            migrationBuilder.DropTable(
                name: "StudentsJournal");

            migrationBuilder.DropTable(
                name: "StudentsJournals");

            migrationBuilder.DropTable(
                name: "UserJournal");

            migrationBuilder.DropTable(
                name: "UsersJournals");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "journal");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
