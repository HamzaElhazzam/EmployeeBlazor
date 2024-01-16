using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeCrudBlazor.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCascadingDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Articles_Id_Article",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Employees_Id_Employee",
                table: "Commandes");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Articles_Id_Article",
                table: "Commandes",
                column: "Id_Article",
                principalTable: "Articles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Employees_Id_Employee",
                table: "Commandes",
                column: "Id_Employee",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Articles_Id_Article",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Employees_Id_Employee",
                table: "Commandes");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Articles_Id_Article",
                table: "Commandes",
                column: "Id_Article",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Employees_Id_Employee",
                table: "Commandes",
                column: "Id_Employee",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
