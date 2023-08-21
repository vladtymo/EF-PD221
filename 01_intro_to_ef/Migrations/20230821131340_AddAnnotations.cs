using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_intro_to_ef.Migrations
{
    public partial class AddAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Countries_CountryId",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Writers");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Writers",
                newName: "DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_CountryId",
                table: "Writers",
                newName: "IX_Writers_CountryId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Writers",
                table: "Writers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "BookId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Writers_AuthorsId",
                table: "AuthorBook",
                column: "AuthorsId",
                principalTable: "Writers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Writers_Countries_CountryId",
                table: "Writers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Writers_AuthorsId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Writers_Countries_CountryId",
                table: "Writers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Writers",
                table: "Writers");

            migrationBuilder.RenameTable(
                name: "Writers",
                newName: "Authors");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Authors",
                newName: "Birthdate");

            migrationBuilder.RenameIndex(
                name: "IX_Writers_CountryId",
                table: "Authors",
                newName: "IX_Authors_CountryId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "BookId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 18, 16, 9, 21, 727, DateTimeKind.Local).AddTicks(5385));

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsId",
                table: "AuthorBook",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Countries_CountryId",
                table: "Authors",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
