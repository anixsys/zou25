using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class SemesterMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "semesters",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "semesters");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "6/8/2023 00:55:48");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bb4af2d-8ce7-4cad-a716-5e4d18fab394", "AQAAAAIAAYagAAAAEPKMUvG07AzBPIijGjuPpPLEEMto74poQJh8wS67SNHaGpHAPhwLLFquSbMmfUTKpw==", "10e39ab3-c4e5-49c6-9ead-35c6a75527c3" });
        }
    }
}
