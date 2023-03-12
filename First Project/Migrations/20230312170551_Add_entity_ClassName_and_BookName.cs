using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace First_Project.Migrations
{
    public partial class Add_entity_ClassName_and_BookName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    ClassNameEn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    ClassNameBn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    Order = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classNames", x => x.Id);
                });

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
                    classNameId = table.Column<int>(nullable: true),
                    BookNameEn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    BookNameBn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    url = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookNames_classNames_classNameId",
                        column: x => x.classNameId,
                        principalTable: "classNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookNames_classNameId",
                table: "bookNames",
                column: "classNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookNames");

            migrationBuilder.DropTable(
                name: "classNames");
        }
    }
}
