﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ordinacija_be.Migrations
{
    public partial class MinTimeBeforeCancel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "MinTimeForCancel",
                table: "Dentists",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinTimeForCancel",
                table: "Dentists");
        }
    }
}