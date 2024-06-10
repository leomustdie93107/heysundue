using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heysundue.Migrations.Article
{
    /// <inheritdoc />
    public partial class AddArticleProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Article",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Article",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Article",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Article");
        }
    }
}
