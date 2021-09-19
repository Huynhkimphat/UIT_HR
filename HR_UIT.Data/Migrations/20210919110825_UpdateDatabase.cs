using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HR_UIT.Data.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttendance_Employees_EmployeeId",
                table: "EmployeeAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDayOff_Letter_Employees_EmployeeId",
                table: "EmployeeDayOff_Letter");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeAccount_PrimaryAccountId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeAddress_PrimaryAddressId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeDayOff_PrimaryDayOffId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalary_Employees_EmployeeId",
                table: "EmployeeSalary");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalary_SalaryDetail_PrimarySalaryDetailId",
                table: "EmployeeSalary");

            migrationBuilder.DropForeignKey(
                name: "FK_Holiday_Create_Employees_EmployeeId",
                table: "Holiday_Create");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryDetail",
                table: "SalaryDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Holiday_Create",
                table: "Holiday_Create");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalary",
                table: "EmployeeSalary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDayOff_Letter",
                table: "EmployeeDayOff_Letter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDayOff",
                table: "EmployeeDayOff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAttendance",
                table: "EmployeeAttendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAddress",
                table: "EmployeeAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAccount",
                table: "EmployeeAccount");

            migrationBuilder.RenameTable(
                name: "SalaryDetail",
                newName: "SalaryDetails");

            migrationBuilder.RenameTable(
                name: "Holiday_Create",
                newName: "HolidayCreates");

            migrationBuilder.RenameTable(
                name: "EmployeeSalary",
                newName: "EmployeeSalaries");

            migrationBuilder.RenameTable(
                name: "EmployeeDayOff_Letter",
                newName: "EmployeeDayOffLetters");

            migrationBuilder.RenameTable(
                name: "EmployeeDayOff",
                newName: "EmployeeDayOffs");

            migrationBuilder.RenameTable(
                name: "EmployeeAttendance",
                newName: "EmployeeAttendances");

            migrationBuilder.RenameTable(
                name: "EmployeeAddress",
                newName: "EmployeeAddresses");

            migrationBuilder.RenameTable(
                name: "EmployeeAccount",
                newName: "EmployeeAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_Holiday_Create_EmployeeId",
                table: "HolidayCreates",
                newName: "IX_HolidayCreates_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalary_PrimarySalaryDetailId",
                table: "EmployeeSalaries",
                newName: "IX_EmployeeSalaries_PrimarySalaryDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalary_EmployeeId",
                table: "EmployeeSalaries",
                newName: "IX_EmployeeSalaries_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDayOff_Letter_EmployeeId",
                table: "EmployeeDayOffLetters",
                newName: "IX_EmployeeDayOffLetters_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeAttendance_EmployeeId",
                table: "EmployeeAttendances",
                newName: "IX_EmployeeAttendances_EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeTypeId",
                table: "Employees",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryDetails",
                table: "SalaryDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HolidayCreates",
                table: "HolidayCreates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalaries",
                table: "EmployeeSalaries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDayOffLetters",
                table: "EmployeeDayOffLetters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDayOffs",
                table: "EmployeeDayOffs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAttendances",
                table: "EmployeeAttendances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAddresses",
                table: "EmployeeAddresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAccounts",
                table: "EmployeeAccounts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameOfHoliday = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    PrimaryHoliday_CreateId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holidays_HolidayCreates_PrimaryHoliday_CreateId",
                        column: x => x.PrimaryHoliday_CreateId,
                        principalTable: "HolidayCreates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_PrimaryHoliday_CreateId",
                table: "Holidays",
                column: "PrimaryHoliday_CreateId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttendances_Employees_EmployeeId",
                table: "EmployeeAttendances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDayOffLetters_Employees_EmployeeId",
                table: "EmployeeDayOffLetters",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeAccounts_PrimaryAccountId",
                table: "Employees",
                column: "PrimaryAccountId",
                principalTable: "EmployeeAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeAddresses_PrimaryAddressId",
                table: "Employees",
                column: "PrimaryAddressId",
                principalTable: "EmployeeAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeDayOffs_PrimaryDayOffId",
                table: "Employees",
                column: "PrimaryDayOffId",
                principalTable: "EmployeeDayOffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId",
                principalTable: "EmployeeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaries_Employees_EmployeeId",
                table: "EmployeeSalaries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaries_SalaryDetails_PrimarySalaryDetailId",
                table: "EmployeeSalaries",
                column: "PrimarySalaryDetailId",
                principalTable: "SalaryDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayCreates_Employees_EmployeeId",
                table: "HolidayCreates",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttendances_Employees_EmployeeId",
                table: "EmployeeAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDayOffLetters_Employees_EmployeeId",
                table: "EmployeeDayOffLetters");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeAccounts_PrimaryAccountId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeAddresses_PrimaryAddressId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeDayOffs_PrimaryDayOffId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaries_Employees_EmployeeId",
                table: "EmployeeSalaries");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaries_SalaryDetails_PrimarySalaryDetailId",
                table: "EmployeeSalaries");

            migrationBuilder.DropForeignKey(
                name: "FK_HolidayCreates_Employees_EmployeeId",
                table: "HolidayCreates");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryDetails",
                table: "SalaryDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HolidayCreates",
                table: "HolidayCreates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalaries",
                table: "EmployeeSalaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDayOffs",
                table: "EmployeeDayOffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDayOffLetters",
                table: "EmployeeDayOffLetters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAttendances",
                table: "EmployeeAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAddresses",
                table: "EmployeeAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAccounts",
                table: "EmployeeAccounts");

            migrationBuilder.DropColumn(
                name: "EmployeeTypeId",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "SalaryDetails",
                newName: "SalaryDetail");

            migrationBuilder.RenameTable(
                name: "HolidayCreates",
                newName: "Holiday_Create");

            migrationBuilder.RenameTable(
                name: "EmployeeSalaries",
                newName: "EmployeeSalary");

            migrationBuilder.RenameTable(
                name: "EmployeeDayOffs",
                newName: "EmployeeDayOff");

            migrationBuilder.RenameTable(
                name: "EmployeeDayOffLetters",
                newName: "EmployeeDayOff_Letter");

            migrationBuilder.RenameTable(
                name: "EmployeeAttendances",
                newName: "EmployeeAttendance");

            migrationBuilder.RenameTable(
                name: "EmployeeAddresses",
                newName: "EmployeeAddress");

            migrationBuilder.RenameTable(
                name: "EmployeeAccounts",
                newName: "EmployeeAccount");

            migrationBuilder.RenameIndex(
                name: "IX_HolidayCreates_EmployeeId",
                table: "Holiday_Create",
                newName: "IX_Holiday_Create_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalaries_PrimarySalaryDetailId",
                table: "EmployeeSalary",
                newName: "IX_EmployeeSalary_PrimarySalaryDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalaries_EmployeeId",
                table: "EmployeeSalary",
                newName: "IX_EmployeeSalary_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDayOffLetters_EmployeeId",
                table: "EmployeeDayOff_Letter",
                newName: "IX_EmployeeDayOff_Letter_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeAttendances_EmployeeId",
                table: "EmployeeAttendance",
                newName: "IX_EmployeeAttendance_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryDetail",
                table: "SalaryDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holiday_Create",
                table: "Holiday_Create",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalary",
                table: "EmployeeSalary",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDayOff",
                table: "EmployeeDayOff",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDayOff_Letter",
                table: "EmployeeDayOff_Letter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAttendance",
                table: "EmployeeAttendance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAddress",
                table: "EmployeeAddress",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAccount",
                table: "EmployeeAccount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttendance_Employees_EmployeeId",
                table: "EmployeeAttendance",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDayOff_Letter_Employees_EmployeeId",
                table: "EmployeeDayOff_Letter",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeAccount_PrimaryAccountId",
                table: "Employees",
                column: "PrimaryAccountId",
                principalTable: "EmployeeAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeAddress_PrimaryAddressId",
                table: "Employees",
                column: "PrimaryAddressId",
                principalTable: "EmployeeAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeDayOff_PrimaryDayOffId",
                table: "Employees",
                column: "PrimaryDayOffId",
                principalTable: "EmployeeDayOff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalary_Employees_EmployeeId",
                table: "EmployeeSalary",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalary_SalaryDetail_PrimarySalaryDetailId",
                table: "EmployeeSalary",
                column: "PrimarySalaryDetailId",
                principalTable: "SalaryDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holiday_Create_Employees_EmployeeId",
                table: "Holiday_Create",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
