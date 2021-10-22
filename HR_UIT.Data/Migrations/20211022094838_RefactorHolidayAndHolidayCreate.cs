using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_UIT.Data.Migrations
{
    public partial class RefactorHolidayAndHolidayCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_HolidayCreates_PrimaryHolidayCreateId",
                table: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_Holidays_PrimaryHolidayCreateId",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "PrimaryHolidayCreateId",
                table: "Holidays");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfHoliday",
                table: "Holidays",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HolidayId",
                table: "HolidayCreates",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExistedAdmin",
                table: "HolidayCreates",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExistedHoliday",
                table: "HolidayCreates",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_HolidayCreates_HolidayId",
                table: "HolidayCreates",
                column: "HolidayId");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayCreates_Holidays_HolidayId",
                table: "HolidayCreates",
                column: "HolidayId",
                principalTable: "Holidays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayCreates_Holidays_HolidayId",
                table: "HolidayCreates");

            migrationBuilder.DropIndex(
                name: "IX_HolidayCreates_HolidayId",
                table: "HolidayCreates");

            migrationBuilder.DropColumn(
                name: "DateOfHoliday",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "HolidayId",
                table: "HolidayCreates");

            migrationBuilder.DropColumn(
                name: "IsExistedAdmin",
                table: "HolidayCreates");

            migrationBuilder.DropColumn(
                name: "IsExistedHoliday",
                table: "HolidayCreates");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryHolidayCreateId",
                table: "Holidays",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_PrimaryHolidayCreateId",
                table: "Holidays",
                column: "PrimaryHolidayCreateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_HolidayCreates_PrimaryHolidayCreateId",
                table: "Holidays",
                column: "PrimaryHolidayCreateId",
                principalTable: "HolidayCreates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
