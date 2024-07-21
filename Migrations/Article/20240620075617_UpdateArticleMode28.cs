using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heysundue.Migrations.Article
{
    /// <inheritdoc />
    public partial class UpdateArticleMode28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Persons",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JoinlistID",
                table: "Joinlists",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonID",
                table: "Persons",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Joinlists_JoinlistID",
                table: "Joinlists",
                column: "JoinlistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Joinlists_Joinlists_JoinlistID",
                table: "Joinlists",
                column: "JoinlistID",
                principalTable: "Joinlists",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_PersonID",
                table: "Persons",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joinlists_Joinlists_JoinlistID",
                table: "Joinlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_PersonID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PersonID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Joinlists_JoinlistID",
                table: "Joinlists");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "JoinlistID",
                table: "Joinlists");
        }
    }
}
