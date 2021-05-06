using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElJournal.Migrations
{
    public partial class AddedLessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Subjects_SubjectID",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_SubjectID",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "SetAt",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "Semester",
                table: "Marks",
                newName: "LessonID");

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubjectID = table.Column<int>(type: "INTEGER", nullable: false),
                    GTSID = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Topic = table.Column<string>(type: "TEXT", nullable: true),
                    Semester = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupToSubjectID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonID);
                    table.ForeignKey(
                        name: "FK_Lessons_GroupToSubjects_GroupToSubjectID",
                        column: x => x.GroupToSubjectID,
                        principalTable: "GroupToSubjects",
                        principalColumn: "GroupToSubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marks_LessonID",
                table: "Marks",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GroupToSubjectID",
                table: "Lessons",
                column: "GroupToSubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Lessons_LessonID",
                table: "Marks",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "LessonID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Lessons_LessonID",
                table: "Marks");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Marks_LessonID",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "LessonID",
                table: "Marks",
                newName: "Semester");

            migrationBuilder.AddColumn<DateTime>(
                name: "SetAt",
                table: "Marks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Marks_SubjectID",
                table: "Marks",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Subjects_SubjectID",
                table: "Marks",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
