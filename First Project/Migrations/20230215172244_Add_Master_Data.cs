using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace First_Project.Migrations
{
    public partial class Add_Master_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    countryCode = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    countryName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    countryNameBn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    shortName = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    isActive = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    latitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    longitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "occupations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    occupationName = table.Column<string>(type: "NVARCHAR(180)", nullable: false),
                    occupationShortName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    shortOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_occupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "religions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    shortName = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_religions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "divisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    countryId = table.Column<int>(nullable: true),
                    divisionCode = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    divisionName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    divisionNameBn = table.Column<string>(nullable: true),
                    shortName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    isActive = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    latitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    longitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_divisions_countries_countryId",
                        column: x => x.countryId,
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    divisionId = table.Column<int>(nullable: false),
                    districtCode = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    districtName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    districtNameBn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    shortName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    isActive = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    latitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    longitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_districts_divisions_divisionId",
                        column: x => x.divisionId,
                        principalTable: "divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thanas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    districtId = table.Column<int>(nullable: true),
                    thanaCode = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    thanaName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    thanaNameBn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    shortName = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    isActive = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    latitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    longitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thanas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thanas_districts_districtId",
                        column: x => x.districtId,
                        principalTable: "districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_districts_divisionId",
                table: "districts",
                column: "divisionId");

            migrationBuilder.CreateIndex(
                name: "IX_divisions_countryId",
                table: "divisions",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_thanas_districtId",
                table: "thanas",
                column: "districtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "occupations");

            migrationBuilder.DropTable(
                name: "religions");

            migrationBuilder.DropTable(
                name: "thanas");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "divisions");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
