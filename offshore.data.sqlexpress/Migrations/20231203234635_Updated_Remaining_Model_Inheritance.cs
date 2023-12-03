using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace offshore.data.models.settings.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Remaining_Model_Inheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_MeasurementTypes_Name",
                schema: "config",
                table: "MeasurementTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "Sites",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "Modules",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "MeasurementUnits",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "Calibrations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_Name",
                schema: "config",
                table: "Sites",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Name",
                schema: "users",
                table: "Permissions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_Name",
                schema: "config",
                table: "Modules",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnits_Name",
                schema: "config",
                table: "MeasurementUnits",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementTypes_Name",
                schema: "config",
                table: "MeasurementTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Calibrations_Name",
                schema: "config",
                table: "Calibrations",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sites_Name",
                schema: "config",
                table: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_Name",
                schema: "users",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Modules_Name",
                schema: "config",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_MeasurementUnits_Name",
                schema: "config",
                table: "MeasurementUnits");

            migrationBuilder.DropIndex(
                name: "IX_MeasurementTypes_Name",
                schema: "config",
                table: "MeasurementTypes");

            migrationBuilder.DropIndex(
                name: "IX_Calibrations_Name",
                schema: "config",
                table: "Calibrations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "MeasurementUnits",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "Calibrations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_MeasurementTypes_Name",
                schema: "config",
                table: "MeasurementTypes",
                column: "Name");
        }
    }
}
