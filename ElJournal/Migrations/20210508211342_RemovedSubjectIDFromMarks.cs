using Microsoft.EntityFrameworkCore.Migrations;

namespace ElJournal.Migrations
{
    public partial class RemovedSubjectIDFromMarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Marks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "Marks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
