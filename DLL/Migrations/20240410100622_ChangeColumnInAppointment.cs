using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyTrackSystem.DLL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnInAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Appointments",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                newName: "IX_Appointments_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Appointments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
