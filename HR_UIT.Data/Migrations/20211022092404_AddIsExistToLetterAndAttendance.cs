using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_UIT.Data.Migrations
{
    public partial class AddIsExistToLetterAndAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_HolidayCreates_PrimaryHoliday_CreateId",
                table: "Holidays");

            migrationBuilder.RenameColumn(
                name: "PrimaryHoliday_CreateId",
                table: "Holidays",
                newName: "PrimaryHolidayCreateId");

            migrationBuilder.RenameIndex(
                name: "IX_Holidays_PrimaryHoliday_CreateId",
                table: "Holidays",
                newName: "IX_Holidays_PrimaryHolidayCreateId");

            migrationBuilder.AddColumn<bool>(
                name: "IsExisted",
                table: "EmployeeDayOffLetters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExisted",
                table: "EmployeeAttendances",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_HolidayCreates_PrimaryHolidayCreateId",
                table: "Holidays",
                column: "PrimaryHolidayCreateId",
                principalTable: "HolidayCreates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_HolidayCreates_PrimaryHolidayCreateId",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "IsExisted",
                table: "EmployeeDayOffLetters");

            migrationBuilder.DropColumn(
                name: "IsExisted",
                table: "EmployeeAttendances");

            migrationBuilder.RenameColumn(
                name: "PrimaryHolidayCreateId",
                table: "Holidays",
                newName: "PrimaryHoliday_CreateId");

            migrationBuilder.RenameIndex(
                name: "IX_Holidays_PrimaryHolidayCreateId",
                table: "Holidays",
                newName: "IX_Holidays_PrimaryHoliday_CreateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_HolidayCreates_PrimaryHoliday_CreateId",
                table: "Holidays",
                column: "PrimaryHoliday_CreateId",
                principalTable: "HolidayCreates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
