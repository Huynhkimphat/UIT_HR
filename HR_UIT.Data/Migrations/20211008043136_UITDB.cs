using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_UIT.Data.Migrations
{
    public partial class UITDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayOffAmmount",
                table: "EmployeeDayOffs",
                newName: "DayOffAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayOffAmount",
                table: "EmployeeDayOffs",
                newName: "DayOffAmmount");
        }
    }
}
