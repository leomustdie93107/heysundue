using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heysundue.Migrations.Article
{
    /// <inheritdoc />
    public partial class UpdateArticleModel99 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_PersonID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PersonID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Persons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Persons",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonID",
                table: "Persons",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_PersonID",
                table: "Persons",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID");
        }
    }
}
