using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heysundue.Migrations.Article
{
    /// <inheritdoc />
    public partial class UpdateArticleModel9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessdoor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<string>(type: "TEXT", nullable: true),
                    SearchColumn = table.Column<string>(type: "TEXT", nullable: true),
                    Room = table.Column<string>(type: "TEXT", nullable: true),
                    Session = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessdoor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Doorsystem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Session = table.Column<string>(type: "TEXT", nullable: true),
                    SessionName = table.Column<string>(type: "TEXT", nullable: true),
                    Room = table.Column<string>(type: "TEXT", nullable: true),
                    TimeRange = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doorsystem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Joinlist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SearchColumn = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<string>(type: "TEXT", nullable: true),
                    EndDate = table.Column<string>(type: "TEXT", nullable: true),
                    SearchKeyword = table.Column<string>(type: "TEXT", nullable: true),
                    Participants = table.Column<string>(type: "TEXT", nullable: true),
                    RegNo = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    ChineseName = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    RegistrationStatus = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joinlist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisplayLocation = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayStatus = table.Column<string>(type: "TEXT", nullable: true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    TotalAmount = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalAmountUSD = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessdoor");

            migrationBuilder.DropTable(
                name: "Doorsystem");

            migrationBuilder.DropTable(
                name: "Joinlist");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Registration");
        }
    }
}
