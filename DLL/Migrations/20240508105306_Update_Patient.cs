using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyTrackSystem.DLL.Migrations
{
    /// <inheritdoc />
    public partial class Update_Patient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhomeNumber",
                table: "Patients",
                newName: "PhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Patients",
                newName: "PhomeNumber");
        }
    }
}
