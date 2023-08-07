using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class systemmoduleMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "View",
                table: "AspNetRoles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "systemmodules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systemmodules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rolesystemmodules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    SystemmoduleId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolesystemmodules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rolesystemmodules_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rolesystemmodules_systemmodules_SystemmoduleId",
                        column: x => x.SystemmoduleId,
                        principalTable: "systemmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "systemsubmodules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SystemmoduleId = table.Column<int>(type: "integer", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systemsubmodules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_systemsubmodules_systemmodules_SystemmoduleId",
                        column: x => x.SystemmoduleId,
                        principalTable: "systemmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rolesystemsubmodules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    RoleSystemmoduleId = table.Column<int>(type: "integer", nullable: false),
                    SystemSubmoduleId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolesystemsubmodules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rolesystemsubmodules_rolesystemmodules_RoleSystemmoduleId",
                        column: x => x.RoleSystemmoduleId,
                        principalTable: "rolesystemmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rolesystemsubmodules_systemsubmodules_SystemSubmoduleId",
                        column: x => x.SystemSubmoduleId,
                        principalTable: "systemsubmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "systempermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SystemSubmoduleId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systempermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_systempermissions_systemsubmodules_SystemSubmoduleId",
                        column: x => x.SystemSubmoduleId,
                        principalTable: "systemsubmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rolesystempermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    RoleSystemsubmoduleId = table.Column<int>(type: "integer", nullable: false),
                    PermissionId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolesystempermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rolesystempermissions_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rolesystempermissions_rolesystemsubmodules_RoleSystemsubmod~",
                        column: x => x.RoleSystemsubmoduleId,
                        principalTable: "rolesystemsubmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rolesystempermissions_systempermissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "systempermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rolesystemmodules_RoleId",
                table: "rolesystemmodules",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_rolesystemmodules_SystemmoduleId",
                table: "rolesystemmodules",
                column: "SystemmoduleId");

            migrationBuilder.CreateIndex(
                name: "IX_rolesystempermissions_PermissionId",
                table: "rolesystempermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_rolesystempermissions_RoleId",
                table: "rolesystempermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_rolesystempermissions_RoleSystemsubmoduleId",
                table: "rolesystempermissions",
                column: "RoleSystemsubmoduleId");

            migrationBuilder.CreateIndex(
                name: "IX_rolesystemsubmodules_RoleSystemmoduleId",
                table: "rolesystemsubmodules",
                column: "RoleSystemmoduleId");

            migrationBuilder.CreateIndex(
                name: "IX_rolesystemsubmodules_SystemSubmoduleId",
                table: "rolesystemsubmodules",
                column: "SystemSubmoduleId");

            migrationBuilder.CreateIndex(
                name: "IX_systempermissions_SystemSubmoduleId",
                table: "systempermissions",
                column: "SystemSubmoduleId");

            migrationBuilder.CreateIndex(
                name: "IX_systemsubmodules_SystemmoduleId",
                table: "systemsubmodules",
                column: "SystemmoduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rolesystempermissions");

            migrationBuilder.DropTable(
                name: "rolesystemsubmodules");

            migrationBuilder.DropTable(
                name: "systempermissions");

            migrationBuilder.DropTable(
                name: "rolesystemmodules");

            migrationBuilder.DropTable(
                name: "systemsubmodules");

            migrationBuilder.DropTable(
                name: "systemmodules");

            migrationBuilder.DropColumn(
                name: "View",
                table: "AspNetRoles");
        }
    }
}
