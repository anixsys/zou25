using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class RegistrationPeriodMigrationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "registrationPeriods",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "7/8/2023 19:56:19");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36c25c2f-d4ac-4c25-8192-2eda270b198b", "AQAAAAIAAYagAAAAEK9cnpPAljmsalKCloNPqzalEdWMXK5do02AC78hLk25IgZ+WM11ra+wc5hFiZbpjw==", "4aa065bd-a5a4-44cc-81a5-9a977683701c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "registrationPeriods");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "6/8/2023 01:59:10");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3f312d9-6d5a-4ae1-86ca-abbd2ae88271", "AQAAAAIAAYagAAAAEDGg1qrElyPV8OsfMqhr28GLjH6YoZjCKYxElSZ9ca9gTImitiPRZpGKcA+YExB2qA==", "3a03587a-48c9-4e92-88db-4c078e28a5ae" });
        }
    }
}
