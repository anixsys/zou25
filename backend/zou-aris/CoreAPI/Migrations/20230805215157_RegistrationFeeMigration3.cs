using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class RegistrationFeeMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "registrationFees");

            migrationBuilder.DropColumn(
                name: "ChangeRequestId",
                table: "registrationFees");

            migrationBuilder.DropColumn(
                name: "InitiatedBy",
                table: "registrationFees");

            migrationBuilder.AddColumn<string>(
                name: "ChangeRequestId",
                table: "registrationFeeTemplates",
                type: "text",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeRequestId",
                table: "registrationFeeTemplates");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "registrationFees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChangeRequestId",
                table: "registrationFees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitiatedBy",
                table: "registrationFees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 22:14:23");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81b4e571-f1de-4420-89e7-dcdb181a5bf9", "AQAAAAIAAYagAAAAEB70ZXkd3sitpco+jlmboHM3BBp+upWmvEnVSrEy5YzXECdAaUy4tI5u8nXU/f45OQ==", "5e0db723-3a29-4534-8c93-48115736d52e" });
        }
    }
}
