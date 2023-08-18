using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_intro_to_ef.Migrations
{
    public partial class SeedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Birthdate", "CountryId", "Name", "Rating", "Surname" },
                values: new object[] { 1, new DateTime(1856, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ivan", null, "Franko" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Birthdate", "CountryId", "Name", "Rating", "Surname" },
                values: new object[] { 2, new DateTime(1814, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Taras", null, "Shevchenko" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "ReviewId", "Title", "Year" },
                values: new object[] { 1, null, null, "Blue Sky", 2017 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "BookId", "Date", "Summary" },
                values: new object[] { 1, new DateTime(2023, 8, 18, 16, 6, 30, 116, DateTimeKind.Local).AddTicks(1561), "Everything is good!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
