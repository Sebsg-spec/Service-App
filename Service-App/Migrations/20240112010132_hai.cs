using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service_App.Migrations
{
    public partial class hai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentStatus_StatusId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_StatusId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CarPlate",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StatusId",
                table: "Appointments",
                column: "StatusId",
                unique: true,
                filter: "[StatusId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentStatus_StatusId",
                table: "Appointments",
                column: "StatusId",
                principalTable: "AppointmentStatus",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentStatus_StatusId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_StatusId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CarPlate",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StatusId",
                table: "Appointments",
                column: "StatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentStatus_StatusId",
                table: "Appointments",
                column: "StatusId",
                principalTable: "AppointmentStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
