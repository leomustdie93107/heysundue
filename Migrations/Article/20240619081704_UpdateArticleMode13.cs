using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heysundue.Migrations.Article
{
    /// <inheritdoc />
    public partial class UpdateArticleMode13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Joinlist",
                table: "Joinlist");

            migrationBuilder.RenameTable(
                name: "Joinlist",
                newName: "Joinlists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Joinlists",
                table: "Joinlists",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Joinlists",
                table: "Joinlists");

            migrationBuilder.RenameTable(
                name: "Joinlists",
                newName: "Joinlist");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Joinlist",
                table: "Joinlist",
                column: "ID");
        }
    }
}
