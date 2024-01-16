using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeCrudBlazor.Migrations
{
    /// <inheritdoc />
    public partial class addbncommandetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prix",
                table: "Articles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "BonCommandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PrixCommande = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(name: "Id_Employee", type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IdArticle = table.Column<int>(name: "Id_Article", type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonCommandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonCommandes_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BonCommandes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BonCommandes_ArticleId",
                table: "BonCommandes",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_BonCommandes_EmployeeId",
                table: "BonCommandes",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonCommandes");

            migrationBuilder.AlterColumn<string>(
                name: "Prix",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
