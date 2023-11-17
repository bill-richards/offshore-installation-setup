using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace offshore.data.models.settings.Migrations
{
    /// <inheritdoc />
    public partial class Added_SpmModule_To_DataContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpmModule_Modules_ModuleId",
                schema: "config",
                table: "SpmModule");

            migrationBuilder.DropForeignKey(
                name: "FK_SpmModule_SinglePointMoorings_SpmId",
                schema: "config",
                table: "SpmModule");

            migrationBuilder.DropForeignKey(
                name: "FK_SpmModule_Sites_SiteId",
                schema: "config",
                table: "SpmModule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpmModule",
                schema: "config",
                table: "SpmModule");

            migrationBuilder.RenameTable(
                name: "SpmModule",
                schema: "config",
                newName: "SpmModules",
                newSchema: "config");

            migrationBuilder.RenameIndex(
                name: "IX_SpmModule_SpmId",
                schema: "config",
                table: "SpmModules",
                newName: "IX_SpmModules_SpmId");

            migrationBuilder.RenameIndex(
                name: "IX_SpmModule_SiteId",
                schema: "config",
                table: "SpmModules",
                newName: "IX_SpmModules_SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_SpmModule_ModuleId",
                schema: "config",
                table: "SpmModules",
                newName: "IX_SpmModules_ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpmModules",
                schema: "config",
                table: "SpmModules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpmModules_Modules_ModuleId",
                schema: "config",
                table: "SpmModules",
                column: "ModuleId",
                principalSchema: "config",
                principalTable: "Modules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpmModules_SinglePointMoorings_SpmId",
                schema: "config",
                table: "SpmModules",
                column: "SpmId",
                principalSchema: "config",
                principalTable: "SinglePointMoorings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpmModules_Sites_SiteId",
                schema: "config",
                table: "SpmModules",
                column: "SiteId",
                principalSchema: "config",
                principalTable: "Sites",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpmModules_Modules_ModuleId",
                schema: "config",
                table: "SpmModules");

            migrationBuilder.DropForeignKey(
                name: "FK_SpmModules_SinglePointMoorings_SpmId",
                schema: "config",
                table: "SpmModules");

            migrationBuilder.DropForeignKey(
                name: "FK_SpmModules_Sites_SiteId",
                schema: "config",
                table: "SpmModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpmModules",
                schema: "config",
                table: "SpmModules");

            migrationBuilder.RenameTable(
                name: "SpmModules",
                schema: "config",
                newName: "SpmModule",
                newSchema: "config");

            migrationBuilder.RenameIndex(
                name: "IX_SpmModules_SpmId",
                schema: "config",
                table: "SpmModule",
                newName: "IX_SpmModule_SpmId");

            migrationBuilder.RenameIndex(
                name: "IX_SpmModules_SiteId",
                schema: "config",
                table: "SpmModule",
                newName: "IX_SpmModule_SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_SpmModules_ModuleId",
                schema: "config",
                table: "SpmModule",
                newName: "IX_SpmModule_ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpmModule",
                schema: "config",
                table: "SpmModule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpmModule_Modules_ModuleId",
                schema: "config",
                table: "SpmModule",
                column: "ModuleId",
                principalSchema: "config",
                principalTable: "Modules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpmModule_SinglePointMoorings_SpmId",
                schema: "config",
                table: "SpmModule",
                column: "SpmId",
                principalSchema: "config",
                principalTable: "SinglePointMoorings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpmModule_Sites_SiteId",
                schema: "config",
                table: "SpmModule",
                column: "SiteId",
                principalSchema: "config",
                principalTable: "Sites",
                principalColumn: "Id");
        }
    }
}
