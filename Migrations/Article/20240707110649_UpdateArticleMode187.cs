using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heysundue.Migrations.Article
{
    /// <inheritdoc />
    public partial class UpdateArticleMode187 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Doorsystem",
                table: "Doorsystem");

            migrationBuilder.RenameTable(
                name: "Doorsystem",
                newName: "Doorsystems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doorsystems",
                table: "Doorsystems",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Doorsystems",
                table: "Doorsystems");

            migrationBuilder.RenameTable(
                name: "Doorsystems",
                newName: "Doorsystem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doorsystem",
                table: "Doorsystem",
                column: "ID");
        }
    }
}
