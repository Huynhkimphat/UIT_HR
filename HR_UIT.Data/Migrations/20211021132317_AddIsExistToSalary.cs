using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_UIT.Data.Migrations
{
    public partial class AddIsExistToSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExisted",
                table: "EmployeeSalaries",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExisted",
                table: "EmployeeSalaries");
        }
    }
}
