using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitForLife.Data.Migrations
{
    public partial class AddCreationOnAndImageUrlToBLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Blogs");
        }
    }
}
