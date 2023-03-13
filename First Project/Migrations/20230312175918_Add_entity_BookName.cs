using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace First_Project.Migrations
{
    public partial class Add_entity_BookName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    classId = table.Column<int>(nullable: true),
                    classInfoId = table.Column<int>(nullable: true),
                    BookNameEn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    BookNameBn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    url = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookNames_classInfos_classInfoId",
                        column: x => x.classInfoId,
                        principalTable: "classInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookNames_classInfoId",
                table: "bookNames",
                column: "classInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookNames");
        }
    }
}
