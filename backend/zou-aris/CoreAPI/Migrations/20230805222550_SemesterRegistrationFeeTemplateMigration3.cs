using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class SemesterRegistrationFeeTemplateMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationFeeTemplateId",
                table: "semesters");

            migrationBuilder.CreateTable(
                name: "semesterRegistrationFeeTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegistrationFeeTemplateId = table.Column<int>(type: "integer", nullable: false),
                    SemesterId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semesterRegistrationFeeTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_semesterRegistrationFeeTemplates_registrationFeeTemplates_R~",
                        column: x => x.RegistrationFeeTemplateId,
                        principalTable: "registrationFeeTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_semesterRegistrationFeeTemplates_semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "6/8/2023 00:25:50");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49cd92b0-32db-49e8-be19-e7bad717d030", "AQAAAAIAAYagAAAAEIJ7sKpjf+eCB8Iz3WsxMbJ58uqJdkfgqHrgRuO1wn3iNBOlD+TsCixWOXq7UDhXFQ==", "59cbe370-7275-499d-baf8-a0f76bc8e5fc" });

            migrationBuilder.CreateIndex(
                name: "IX_semesterRegistrationFeeTemplates_RegistrationFeeTemplateId",
                table: "semesterRegistrationFeeTemplates",
                column: "RegistrationFeeTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_semesterRegistrationFeeTemplates_SemesterId",
                table: "semesterRegistrationFeeTemplates",
                column: "SemesterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "semesterRegistrationFeeTemplates");

            migrationBuilder.AddColumn<int>(
                name: "RegistrationFeeTemplateId",
                table: "semesters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 23:51:57");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfef39f9-6a2b-488b-8ff9-e6605ce36b38", "AQAAAAIAAYagAAAAEFl1Pdo4rYSNXrNqSIWmo+f5yFPsQdhktMNiAPXJ6+eqZ82Mlu9792NRcnN6gkLTGg==", "2372c118-885e-48e6-92ba-a47734f378d5" });
        }
    }
}
