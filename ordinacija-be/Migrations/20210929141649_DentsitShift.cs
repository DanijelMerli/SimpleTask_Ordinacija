using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ordinacija_be.Migrations
{
    public partial class DentsitShift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "ShiftEnd",
                table: "Dentists",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ShiftStart",
                table: "Dentists",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftEnd",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "ShiftStart",
                table: "Dentists");
        }
    }
}
