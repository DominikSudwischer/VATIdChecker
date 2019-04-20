using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VATIdChecker.Migrations
{
    public partial class MyFirstMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Companies",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastWebServiceCall",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Valid",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SecondsBetweenRequests = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_LastWebServiceCall",
                table: "Companies",
                column: "LastWebServiceCall");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Valid",
                table: "Companies",
                column: "Valid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Companies_LastWebServiceCall",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Valid",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastWebServiceCall",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Valid",
                table: "Companies");
        }
    }
}
