using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace First_Project.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    NameBn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    NameBN = table.Column<string>(nullable: true),
                    NameEN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    NameBN = table.Column<string>(nullable: true),
                    NameEN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Roll = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    sectionId = table.Column<int>(nullable: true),
                    classInfoId = table.Column<int>(nullable: true),
                    genderId = table.Column<int>(nullable: true),
                    isActive = table.Column<int>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentInfos_classInfos_classInfoId",
                        column: x => x.classInfoId,
                        principalTable: "classInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_studentInfos_genders_genderId",
                        column: x => x.genderId,
                        principalTable: "genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_studentInfos_sections_sectionId",
                        column: x => x.sectionId,
                        principalTable: "sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "resultsheets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    TotalMarks = table.Column<int>(nullable: false),
                    Grade = table.Column<string>(nullable: true),
                    studentInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resultsheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resultsheets_studentInfos_studentInfoId",
                        column: x => x.studentInfoId,
                        principalTable: "studentInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_resultsheets_studentInfoId",
                table: "resultsheets",
                column: "studentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_studentInfos_classInfoId",
                table: "studentInfos",
                column: "classInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_studentInfos_genderId",
                table: "studentInfos",
                column: "genderId");

            migrationBuilder.CreateIndex(
                name: "IX_studentInfos_sectionId",
                table: "studentInfos",
                column: "sectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "resultsheets");

            migrationBuilder.DropTable(
                name: "studentInfos");

            migrationBuilder.DropTable(
                name: "classInfos");

            migrationBuilder.DropTable(
                name: "genders");

            migrationBuilder.DropTable(
                name: "sections");
        }
    }
}
