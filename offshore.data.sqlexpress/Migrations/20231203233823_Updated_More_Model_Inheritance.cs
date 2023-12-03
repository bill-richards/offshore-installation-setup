using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace offshore.data.models.settings.Migrations
{
    /// <inheritdoc />
    public partial class Updated_More_Model_Inheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "Sensors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "config",
                table: "Alarms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SinglePointMoorings_Name",
                schema: "config",
                table: "SinglePointMoorings",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_Name",
                schema: "config",
                table: "Sensors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_Name",
                schema: "config",
                table: "Alarms",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SinglePointMoorings_Name",
                schema: "config",
                table: "SinglePointMoorings");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_Name",
                schema: "config",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Alarms_Name",
                schema: "config",
                table: "Alarms");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "config",
                table: "Alarms");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "Sensors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
