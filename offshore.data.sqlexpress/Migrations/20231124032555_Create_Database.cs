﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace offshore.data.models.settings.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "biz");

            migrationBuilder.EnsureSchema(
                name: "config");

            migrationBuilder.EnsureSchema(
                name: "lang");

            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "biz",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "biz",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "lang",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Display = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementTypes",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementTypes", x => x.Id);
                    table.UniqueConstraint("AK_MeasurementTypes_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnits",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Factor = table.Column<double>(type: "float", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraphMinimum = table.Column<long>(type: "bigint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AssignSysAdmin = table.Column<bool>(type: "bit", nullable: true),
                    CreateUser = table.Column<bool>(type: "bit", nullable: true),
                    UpdateUser = table.Column<bool>(type: "bit", nullable: true),
                    DeleteUser = table.Column<bool>(type: "bit", nullable: true),
                    EnableUser = table.Column<bool>(type: "bit", nullable: true),
                    CreateSite = table.Column<bool>(type: "bit", nullable: true),
                    UpdateSite = table.Column<bool>(type: "bit", nullable: true),
                    DeleteSite = table.Column<bool>(type: "bit", nullable: true),
                    EnableSite = table.Column<bool>(type: "bit", nullable: true),
                    CreateConsignment = table.Column<bool>(type: "bit", nullable: true),
                    UpdateConsignment = table.Column<bool>(type: "bit", nullable: true),
                    DeleteConsignment = table.Column<bool>(type: "bit", nullable: true),
                    EnableConsignment = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.UniqueConstraint("AK_Permissions_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Receivers",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumValue = table.Column<double>(type: "float", nullable: false),
                    MaximumValue = table.Column<double>(type: "float", nullable: false),
                    DecimalPlaces = table.Column<long>(type: "bigint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelemetryData",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelemetryData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelephoneTypes",
                schema: "biz",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translatables",
                schema: "lang",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translatables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "biz",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "biz",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryCodes",
                schema: "biz",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DialingCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryCodes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "biz",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionSetId = table.Column<long>(type: "bigint", nullable: false),
                    Weight = table.Column<long>(type: "bigint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.UniqueConstraint("AK_Roles_Type", x => x.Type);
                    table.ForeignKey(
                        name: "FK_Roles_Permissions_PermissionSetId",
                        column: x => x.PermissionSetId,
                        principalSchema: "users",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                schema: "lang",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    TranslatableId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.UniqueConstraint("AK_Translations_LanguageId_TranslatableId", x => new { x.LanguageId, x.TranslatableId });
                    table.ForeignKey(
                        name: "FK_Translations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "lang",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translations_Translatables_TranslatableId",
                        column: x => x.TranslatableId,
                        principalSchema: "lang",
                        principalTable: "Translatables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calibrations",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalibratedById = table.Column<long>(type: "bigint", nullable: false),
                    DataPosition = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Raw = table.Column<long>(type: "bigint", nullable: false),
                    Zero = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Data = table.Column<double>(type: "float", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calibrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calibrations_Users_CalibratedById",
                        column: x => x.CalibratedById,
                        principalSchema: "users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageUser",
                schema: "config",
                columns: table => new
                {
                    LanguagesId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageUser", x => new { x.LanguagesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_LanguageUser_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalSchema: "lang",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteConfigurations",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortNumber = table.Column<long>(type: "bigint", nullable: false),
                    BaudRate = table.Column<long>(type: "bigint", nullable: false),
                    TcpPort = table.Column<long>(type: "bigint", nullable: false),
                    LogData = table.Column<long>(type: "bigint", nullable: false),
                    SqlConnection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SyncLicence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SyncPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeZone = table.Column<long>(type: "bigint", nullable: false),
                    AudibleAlarm = table.Column<bool>(type: "bit", nullable: false),
                    SmsAlarm = table.Column<bool>(type: "bit", nullable: false),
                    SmsSender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmsInterval = table.Column<long>(type: "bigint", nullable: false),
                    EmailAlarm = table.Column<bool>(type: "bit", nullable: false),
                    Modbus = table.Column<bool>(type: "bit", nullable: false),
                    Pilot = table.Column<bool>(type: "bit", nullable: false),
                    ReceiverTypeId = table.Column<long>(type: "bigint", nullable: false),
                    EmailUserId = table.Column<long>(type: "bigint", nullable: true),
                    SmsUserId = table.Column<long>(type: "bigint", nullable: true),
                    SyncUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteConfigurations_Receivers_ReceiverTypeId",
                        column: x => x.ReceiverTypeId,
                        principalSchema: "config",
                        principalTable: "Receivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteConfigurations_Users_EmailUserId",
                        column: x => x.EmailUserId,
                        principalSchema: "users",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SiteConfigurations_Users_SmsUserId",
                        column: x => x.SmsUserId,
                        principalSchema: "users",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SiteConfigurations_Users_SyncUserId",
                        column: x => x.SyncUserId,
                        principalSchema: "users",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "biz",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "biz",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelephoneNumbers",
                schema: "biz",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    CountryCodeId = table.Column<long>(type: "bigint", nullable: false),
                    Number = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelephoneNumbers_CountryCodes_CountryCodeId",
                        column: x => x.CountryCodeId,
                        principalSchema: "biz",
                        principalTable: "CountryCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelephoneNumbers_TelephoneTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "biz",
                        principalTable: "TelephoneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                schema: "users",
                columns: table => new
                {
                    RolesId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "users",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleSensor",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<long>(type: "bigint", nullable: false),
                    SensorId = table.Column<long>(type: "bigint", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataArrayPosition = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    TelemetryId = table.Column<long>(type: "bigint", nullable: false),
                    MeasurementId = table.Column<long>(type: "bigint", nullable: false),
                    CalibrationId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleSensor_Calibrations_CalibrationId",
                        column: x => x.CalibrationId,
                        principalSchema: "config",
                        principalTable: "Calibrations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModuleSensor_MeasurementTypes_MeasurementId",
                        column: x => x.MeasurementId,
                        principalSchema: "config",
                        principalTable: "MeasurementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleSensor_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "config",
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleSensor_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalSchema: "config",
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleSensor_TelemetryData_TelemetryId",
                        column: x => x.TelemetryId,
                        principalSchema: "config",
                        principalTable: "TelemetryData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "biz",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "biz",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactLocation",
                schema: "biz",
                columns: table => new
                {
                    ContactsId = table.Column<long>(type: "bigint", nullable: false),
                    LocationsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLocation", x => new { x.ContactsId, x.LocationsId });
                    table.ForeignKey(
                        name: "FK_ContactLocation_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalSchema: "biz",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactLocation_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalSchema: "biz",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactTelephoneNumber",
                schema: "biz",
                columns: table => new
                {
                    ContactsId = table.Column<long>(type: "bigint", nullable: false),
                    TelephoneNumbersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTelephoneNumber", x => new { x.ContactsId, x.TelephoneNumbersId });
                    table.ForeignKey(
                        name: "FK_ContactTelephoneNumber_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalSchema: "biz",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactTelephoneNumber_TelephoneNumbers_TelephoneNumbersId",
                        column: x => x.TelephoneNumbersId,
                        principalSchema: "biz",
                        principalTable: "TelephoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelephoneNumberUser",
                schema: "config",
                columns: table => new
                {
                    TelephoneNumbersId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneNumberUser", x => new { x.TelephoneNumbersId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TelephoneNumberUser_TelephoneNumbers_TelephoneNumbersId",
                        column: x => x.TelephoneNumbersId,
                        principalSchema: "biz",
                        principalTable: "TelephoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelephoneNumberUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alarms",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlarmBit = table.Column<bool>(type: "bit", nullable: false),
                    Threshold = table.Column<double>(type: "float", nullable: false),
                    MeasurementUnitId = table.Column<long>(type: "bigint", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayColour = table.Column<long>(type: "bigint", nullable: false),
                    Interval = table.Column<long>(type: "bigint", nullable: false),
                    RaiseSound = table.Column<bool>(type: "bit", nullable: false),
                    SendSms = table.Column<bool>(type: "bit", nullable: false),
                    SendEmail = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModuleSensorId = table.Column<long>(type: "bigint", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alarms_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalSchema: "config",
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alarms_ModuleSensor_ModuleSensorId",
                        column: x => x.ModuleSensorId,
                        principalSchema: "config",
                        principalTable: "ModuleSensor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    ConfigurationId = table.Column<long>(type: "bigint", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sites_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "biz",
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sites_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "biz",
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sites_SiteConfigurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalSchema: "config",
                        principalTable: "SiteConfigurations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SinglePointMoorings",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompassAdjustment = table.Column<int>(type: "int", nullable: false),
                    WindAdjustment = table.Column<int>(type: "int", nullable: false),
                    AwacPosition = table.Column<int>(type: "int", nullable: false),
                    GpsPlumLatitude = table.Column<double>(type: "float", nullable: false),
                    GpsPlumLongitude = table.Column<double>(type: "float", nullable: false),
                    GpsToUse = table.Column<int>(type: "int", nullable: false),
                    GpsDistanceAdjustment = table.Column<int>(type: "int", nullable: false),
                    GpsBearingAdjustment = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinglePointMoorings", x => x.Id);
                    table.UniqueConstraint("AK_SinglePointMoorings_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_SinglePointMoorings_Sites_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "config",
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteMeasurementUnits",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<long>(type: "bigint", nullable: false),
                    MeasurementId = table.Column<long>(type: "bigint", nullable: false),
                    UnitsId = table.Column<long>(type: "bigint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteMeasurementUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteMeasurementUnits_MeasurementTypes_MeasurementId",
                        column: x => x.MeasurementId,
                        principalSchema: "config",
                        principalTable: "MeasurementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteMeasurementUnits_MeasurementUnits_UnitsId",
                        column: x => x.UnitsId,
                        principalSchema: "config",
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteMeasurementUnits_Sites_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "config",
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteUsers",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteUsers_Sites_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "config",
                        principalTable: "Sites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SiteUsers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "users",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Consignments",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpmId = table.Column<long>(type: "bigint", nullable: false),
                    TankerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TankerImo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TankerLength = table.Column<long>(type: "bigint", nullable: false),
                    TankerBeam = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BowOffset = table.Column<long>(type: "bigint", nullable: false),
                    HeadOffset = table.Column<long>(type: "bigint", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consignments_SinglePointMoorings_SpmId",
                        column: x => x.SpmId,
                        principalSchema: "config",
                        principalTable: "SinglePointMoorings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiveData",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelemetryDataId = table.Column<long>(type: "bigint", nullable: false),
                    Processed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SinglePointMooringId = table.Column<long>(type: "bigint", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiveData_SinglePointMoorings_SinglePointMooringId",
                        column: x => x.SinglePointMooringId,
                        principalSchema: "config",
                        principalTable: "SinglePointMoorings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LiveData_TelemetryData_TelemetryDataId",
                        column: x => x.TelemetryDataId,
                        principalSchema: "config",
                        principalTable: "TelemetryData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleSinglePointMooring",
                schema: "config",
                columns: table => new
                {
                    ModulesId = table.Column<long>(type: "bigint", nullable: false),
                    SinglePointMooringsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleSinglePointMooring", x => new { x.ModulesId, x.SinglePointMooringsId });
                    table.ForeignKey(
                        name: "FK_ModuleSinglePointMooring_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalSchema: "config",
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleSinglePointMooring_SinglePointMoorings_SinglePointMooringsId",
                        column: x => x.SinglePointMooringsId,
                        principalSchema: "config",
                        principalTable: "SinglePointMoorings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedData",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpmId = table.Column<long>(type: "bigint", nullable: false),
                    TelemetryDataId = table.Column<long>(type: "bigint", nullable: false),
                    RawData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessedData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivedData_SinglePointMoorings_SpmId",
                        column: x => x.SpmId,
                        principalSchema: "config",
                        principalTable: "SinglePointMoorings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceivedData_TelemetryData_TelemetryDataId",
                        column: x => x.TelemetryDataId,
                        principalSchema: "config",
                        principalTable: "TelemetryData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChangeLogs",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SiteId = table.Column<long>(type: "bigint", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChangeLogs_SiteUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "config",
                        principalTable: "SiteUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeLogs_Sites_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "config",
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                schema: "biz",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_MeasurementUnitId",
                schema: "config",
                table: "Alarms",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_ModuleSensorId",
                schema: "config",
                table: "Alarms",
                column: "ModuleSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Calibrations_CalibratedById",
                schema: "config",
                table: "Calibrations",
                column: "CalibratedById");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeLogs_Date",
                schema: "config",
                table: "ChangeLogs",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeLogs_SiteId",
                schema: "config",
                table: "ChangeLogs",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeLogs_UserId",
                schema: "config",
                table: "ChangeLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_LocationId",
                schema: "biz",
                table: "Companies",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consignments_SpmId",
                schema: "config",
                table: "Consignments",
                column: "SpmId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactLocation_LocationsId",
                schema: "biz",
                table: "ContactLocation",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTelephoneNumber_TelephoneNumbersId",
                schema: "biz",
                table: "ContactTelephoneNumber",
                column: "TelephoneNumbersId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCodes_CountryId",
                schema: "biz",
                table: "CountryCodes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCodes_DialingCode_CountryId",
                schema: "biz",
                table: "CountryCodes",
                columns: new[] { "DialingCode", "CountryId" });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageUser_UsersId",
                schema: "config",
                table: "LanguageUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveData_SinglePointMooringId",
                schema: "config",
                table: "LiveData",
                column: "SinglePointMooringId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveData_TelemetryDataId",
                schema: "config",
                table: "LiveData",
                column: "TelemetryDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                schema: "biz",
                table: "Locations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleSensor_CalibrationId",
                schema: "config",
                table: "ModuleSensor",
                column: "CalibrationId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleSensor_MeasurementId",
                schema: "config",
                table: "ModuleSensor",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleSensor_ModuleId",
                schema: "config",
                table: "ModuleSensor",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleSensor_SensorId",
                schema: "config",
                table: "ModuleSensor",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleSensor_TelemetryId",
                schema: "config",
                table: "ModuleSensor",
                column: "TelemetryId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleSinglePointMooring_SinglePointMooringsId",
                schema: "config",
                table: "ModuleSinglePointMooring",
                column: "SinglePointMooringsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedData_SpmId",
                schema: "config",
                table: "ReceivedData",
                column: "SpmId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedData_TelemetryDataId",
                schema: "config",
                table: "ReceivedData",
                column: "TelemetryDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PermissionSetId",
                schema: "users",
                table: "Roles",
                column: "PermissionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                schema: "users",
                table: "RoleUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SinglePointMoorings_SiteId",
                schema: "config",
                table: "SinglePointMoorings",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteConfigurations_EmailUserId",
                schema: "config",
                table: "SiteConfigurations",
                column: "EmailUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteConfigurations_ReceiverTypeId",
                schema: "config",
                table: "SiteConfigurations",
                column: "ReceiverTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteConfigurations_SmsUserId",
                schema: "config",
                table: "SiteConfigurations",
                column: "SmsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteConfigurations_SyncUserId",
                schema: "config",
                table: "SiteConfigurations",
                column: "SyncUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteMeasurementUnits_MeasurementId",
                schema: "config",
                table: "SiteMeasurementUnits",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteMeasurementUnits_SiteId",
                schema: "config",
                table: "SiteMeasurementUnits",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteMeasurementUnits_UnitsId",
                schema: "config",
                table: "SiteMeasurementUnits",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_CompanyId",
                schema: "config",
                table: "Sites",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_ConfigurationId",
                schema: "config",
                table: "Sites",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_LocationId",
                schema: "config",
                table: "Sites",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteUsers_SiteId",
                schema: "config",
                table: "SiteUsers",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteUsers_UserId",
                schema: "config",
                table: "SiteUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneNumbers_CountryCodeId",
                schema: "biz",
                table: "TelephoneNumbers",
                column: "CountryCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneNumbers_Number",
                schema: "biz",
                table: "TelephoneNumbers",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneNumbers_TypeId",
                schema: "biz",
                table: "TelephoneNumbers",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneNumberUser_UsersId",
                schema: "config",
                table: "TelephoneNumberUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Translatables_Name",
                schema: "lang",
                table: "Translatables",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Translations_TranslatableId",
                schema: "lang",
                table: "Translations",
                column: "TranslatableId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                schema: "users",
                table: "Users",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarms",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ChangeLogs",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Consignments",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ContactLocation",
                schema: "biz");

            migrationBuilder.DropTable(
                name: "ContactTelephoneNumber",
                schema: "biz");

            migrationBuilder.DropTable(
                name: "LanguageUser",
                schema: "config");

            migrationBuilder.DropTable(
                name: "LiveData",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ModuleSinglePointMooring",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ReceivedData",
                schema: "config");

            migrationBuilder.DropTable(
                name: "RoleUser",
                schema: "users");

            migrationBuilder.DropTable(
                name: "SiteMeasurementUnits",
                schema: "config");

            migrationBuilder.DropTable(
                name: "TelephoneNumberUser",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Translations",
                schema: "lang");

            migrationBuilder.DropTable(
                name: "ModuleSensor",
                schema: "config");

            migrationBuilder.DropTable(
                name: "SiteUsers",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "biz");

            migrationBuilder.DropTable(
                name: "SinglePointMoorings",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "users");

            migrationBuilder.DropTable(
                name: "MeasurementUnits",
                schema: "config");

            migrationBuilder.DropTable(
                name: "TelephoneNumbers",
                schema: "biz");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "lang");

            migrationBuilder.DropTable(
                name: "Translatables",
                schema: "lang");

            migrationBuilder.DropTable(
                name: "Calibrations",
                schema: "config");

            migrationBuilder.DropTable(
                name: "MeasurementTypes",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Modules",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Sensors",
                schema: "config");

            migrationBuilder.DropTable(
                name: "TelemetryData",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Sites",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "users");

            migrationBuilder.DropTable(
                name: "CountryCodes",
                schema: "biz");

            migrationBuilder.DropTable(
                name: "TelephoneTypes",
                schema: "biz");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "biz");

            migrationBuilder.DropTable(
                name: "SiteConfigurations",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "biz");

            migrationBuilder.DropTable(
                name: "Receivers",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "users");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "biz");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "biz");
        }
    }
}
