using Microsoft.EntityFrameworkCore.Migrations;

namespace DepartIOApp.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "departid",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departid",
                table: "Employees",
                column: "departid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_departid",
                table: "Employees",
                column: "departid",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_departid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_departid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "departid",
                table: "Employees");
        }
    }
}
