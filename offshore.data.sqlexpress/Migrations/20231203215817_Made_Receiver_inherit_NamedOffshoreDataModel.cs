using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace offshore.data.models.settings.Migrations
{
    /// <inheritdoc />
    public partial class Made_Receiver_inherit_NamedOffshoreDataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "config",
                table: "Receivers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "config",
                table: "Receivers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_Name",
                schema: "config",
                table: "Receivers",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Receivers_Name",
                schema: "config",
                table: "Receivers");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "config",
                table: "Receivers");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "config",
                table: "Receivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
