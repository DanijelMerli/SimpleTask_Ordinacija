using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ordinacija_be.Migrations
{
    public partial class AppointmentDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationId",
                table: "Appointments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppointmentDuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    DentistId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentDuration_Dentists_DentistId",
                        column: x => x.DentistId,
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DurationId",
                table: "Appointments",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDuration_DentistId",
                table: "AppointmentDuration",
                column: "DentistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentDuration_DurationId",
                table: "Appointments",
                column: "DurationId",
                principalTable: "AppointmentDuration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentDuration_DurationId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentDuration");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DurationId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DurationId",
                table: "Appointments");
        }
    }
}
