using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace offshore.data.models.settings.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel_Inheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Translatables_Name",
                schema: "lang",
                table: "Translatables");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "biz",
                table: "TelephoneTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "biz",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "lang",
                table: "Languages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "biz",
                table: "Countries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "biz",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "biz",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Translatables_Name",
                schema: "lang",
                table: "Translatables",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneTypes_Name",
                schema: "biz",
                table: "TelephoneTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Name",
                schema: "biz",
                table: "Locations",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                schema: "lang",
                table: "Languages",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                schema: "biz",
                table: "Countries",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Name",
                schema: "biz",
                table: "Contacts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Name",
                schema: "biz",
                table: "Companies",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Translatables_Name",
                schema: "lang",
                table: "Translatables");

            migrationBuilder.DropIndex(
                name: "IX_TelephoneTypes_Name",
                schema: "biz",
                table: "TelephoneTypes");

            migrationBuilder.DropIndex(
                name: "IX_Locations_Name",
                schema: "biz",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Languages_Name",
                schema: "lang",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                schema: "biz",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Name",
                schema: "biz",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Name",
                schema: "biz",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "biz",
                table: "TelephoneTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "biz",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "lang",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "biz",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "biz",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "biz",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Translatables_Name",
                schema: "lang",
                table: "Translatables",
                column: "Name",
                unique: true);
        }
    }
}
