using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    public partial class RemoveFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Reviews_ReviewId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ReviewId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "BookId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 18, 16, 9, 21, 727, DateTimeKind.Local).AddTicks(5385));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "BookId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 18, 16, 6, 30, 116, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReviewId",
                table: "Books",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Reviews_ReviewId",
                table: "Books",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "BookId");
        }
    }
}
