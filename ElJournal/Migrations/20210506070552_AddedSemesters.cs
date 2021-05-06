using Microsoft.EntityFrameworkCore.Migrations;

namespace ElJournal.Migrations
{
    public partial class AddedSemesters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_GroupToSubjects_GroupToSubjectID",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_GroupToSubjectID",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "GTSID",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "GroupToSubjectID",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "Semester",
                table: "Lessons",
                newName: "SemesterID");

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    SemesterID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupToSubjectID = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.SemesterID);
                    table.ForeignKey(
                        name: "FK_Semesters_GroupToSubjects_GroupToSubjectID",
                        column: x => x.GroupToSubjectID,
                        principalTable: "GroupToSubjects",
                        principalColumn: "GroupToSubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SemesterID",
                table: "Lessons",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_GroupToSubjectID",
                table: "Semesters",
                column: "GroupToSubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Semesters_SemesterID",
                table: "Lessons",
                column: "SemesterID",
                principalTable: "Semesters",
                principalColumn: "SemesterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Semesters_SemesterID",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_SemesterID",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "SemesterID",
                table: "Lessons",
                newName: "Semester");

            migrationBuilder.AddColumn<int>(
                name: "GTSID",
                table: "Lessons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupToSubjectID",
                table: "Lessons",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GroupToSubjectID",
                table: "Lessons",
                column: "GroupToSubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_GroupToSubjects_GroupToSubjectID",
                table: "Lessons",
                column: "GroupToSubjectID",
                principalTable: "GroupToSubjects",
                principalColumn: "GroupToSubjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
