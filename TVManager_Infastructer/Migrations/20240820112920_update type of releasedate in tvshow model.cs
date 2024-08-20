using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TVManager_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetypeofreleasedateintvshowmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "TVShows",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageID", "Name" },
                values: new object[,]
                {
                    { new Guid("83efb796-df81-4caa-b173-43d3ce6dc7d3"), "English" },
                    { new Guid("8542701e-340a-4bd8-b00d-4990cbb67c73"), "Arabic" },
                    { new Guid("e0b27e76-54cd-485b-8994-552dc8f1a62d"), "France" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageID",
                keyValue: new Guid("83efb796-df81-4caa-b173-43d3ce6dc7d3"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageID",
                keyValue: new Guid("8542701e-340a-4bd8-b00d-4990cbb67c73"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageID",
                keyValue: new Guid("e0b27e76-54cd-485b-8994-552dc8f1a62d"));

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "TVShows",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
