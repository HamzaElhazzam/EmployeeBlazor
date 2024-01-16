using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeCrudBlazor.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PrixCommande = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(name: "Id_Employee", type: "int", nullable: false),
                    IdArticle = table.Column<int>(name: "Id_Article", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Articles_Id_Article",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commandes_Employees_Id_Employee",
                        column: x => x.IdEmployee,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_Id_Article",
                table: "Commandes",
                column: "Id_Article");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_Id_Employee",
                table: "Commandes",
                column: "Id_Employee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.CreateTable(
                name: "BonCommandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdArticle = table.Column<int>(name: "Id_Article", type: "int", nullable: false),
                    IdEmployee = table.Column<int>(name: "Id_Employee", type: "int", nullable: false),
                    PrixCommande = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
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
    }
}
