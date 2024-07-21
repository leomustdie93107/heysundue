using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heysundue.Migrations.Article
{
    /// <inheritdoc />
    public partial class UpdateArticleMode64 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Accessdoor",
                table: "Accessdoor");

            migrationBuilder.RenameTable(
                name: "Accessdoor",
                newName: "Accessdoors");

            migrationBuilder.AddColumn<int>(
                name: "AccessdoorID",
                table: "Accessdoors",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accessdoors",
                table: "Accessdoors",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Accessdoors_AccessdoorID",
                table: "Accessdoors",
                column: "AccessdoorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessdoors_Accessdoors_AccessdoorID",
                table: "Accessdoors",
                column: "AccessdoorID",
                principalTable: "Accessdoors",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessdoors_Accessdoors_AccessdoorID",
                table: "Accessdoors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accessdoors",
                table: "Accessdoors");

            migrationBuilder.DropIndex(
                name: "IX_Accessdoors_AccessdoorID",
                table: "Accessdoors");

            migrationBuilder.DropColumn(
                name: "AccessdoorID",
                table: "Accessdoors");

            migrationBuilder.RenameTable(
                name: "Accessdoors",
                newName: "Accessdoor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accessdoor",
                table: "Accessdoor",
                column: "ID");
        }
    }
}
