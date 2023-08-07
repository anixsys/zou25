using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class SemesterMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "6/8/2023 01:45:09");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a44b7d0-6989-416e-a25f-15992c3aacdd", "AQAAAAIAAYagAAAAEOUhrYbzOUs/wOOf2kud2GCQ3so4V2lo/a1kQNTLHhD1rmdFFY91loYW5sTDEn6Q2Q==", "4910402d-16fb-4f80-8be5-1c3539675e2e" });
        }
    }
}
