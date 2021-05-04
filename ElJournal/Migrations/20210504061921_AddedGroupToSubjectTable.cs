using Microsoft.EntityFrameworkCore.Migrations;

namespace ElJournal.Migrations
{
    public partial class AddedGroupToSubjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupToSubjects",
                columns: table => new
                {
                    GroupToSubjectID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupID = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupToSubjects", x => x.GroupToSubjectID);
                    table.ForeignKey(
                        name: "FK_GroupToSubjects_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupToSubjects_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupToSubjects_GroupID",
                table: "GroupToSubjects",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupToSubjects_SubjectID",
                table: "GroupToSubjects",
                column: "SubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupToSubjects");
        }
    }
}
