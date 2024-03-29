﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service_App.Migrations
{
    public partial class serviceemployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ServiceId",
                table: "Employees",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Services_ServiceId",
                table: "Employees",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Services_ServiceId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ServiceId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Employees");
        }
    }
}
