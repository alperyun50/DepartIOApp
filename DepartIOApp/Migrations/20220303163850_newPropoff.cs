using Microsoft.EntityFrameworkCore.Migrations;

namespace DepartIOApp.Migrations
{
    public partial class newPropoff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
