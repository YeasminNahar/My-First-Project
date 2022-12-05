using Microsoft.EntityFrameworkCore.Migrations;

namespace First_Project.Migrations
{
    public partial class tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sectionId",
                table: "studentsInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentsInfo_sectionId",
                table: "studentsInfo",
                column: "sectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentsInfo_sectionsInfo_sectionId",
                table: "studentsInfo",
                column: "sectionId",
                principalTable: "sectionsInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentsInfo_sectionsInfo_sectionId",
                table: "studentsInfo");

            migrationBuilder.DropIndex(
                name: "IX_studentsInfo_sectionId",
                table: "studentsInfo");

            migrationBuilder.DropColumn(
                name: "sectionId",
                table: "studentsInfo");
        }
    }
}
