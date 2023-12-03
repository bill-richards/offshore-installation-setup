using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace offshore.data.models.settings.Migrations
{
    /// <inheritdoc />
    public partial class Added_Name_to_SiteConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "TelemetryData",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "config",
                table: "SiteConfigurations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TelemetryData_Name",
                schema: "config",
                table: "TelemetryData",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SiteConfigurations_Name",
                schema: "config",
                table: "SiteConfigurations",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TelemetryData_Name",
                schema: "config",
                table: "TelemetryData");

            migrationBuilder.DropIndex(
                name: "IX_SiteConfigurations_Name",
                schema: "config",
                table: "SiteConfigurations");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "config",
                table: "SiteConfigurations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "config",
                table: "TelemetryData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
