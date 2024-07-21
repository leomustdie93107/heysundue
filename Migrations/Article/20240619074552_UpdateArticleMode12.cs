using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heysundue.Migrations.Article
{
    /// <inheritdoc />
    public partial class UpdateArticleMode12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Participants",
                table: "Joinlist");

            migrationBuilder.DropColumn(
                name: "SearchColumn",
                table: "Joinlist");

            migrationBuilder.DropColumn(
                name: "SearchKeyword",
                table: "Joinlist");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Joinlist",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Joinlist",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Joinlist",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Joinlist",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Participants",
                table: "Joinlist",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchColumn",
                table: "Joinlist",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchKeyword",
                table: "Joinlist",
                type: "TEXT",
                nullable: true);
        }
    }
}
