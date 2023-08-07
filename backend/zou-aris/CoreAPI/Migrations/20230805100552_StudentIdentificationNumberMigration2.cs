using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class StudentIdentificationNumberMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "students",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 12:05:52");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5074f30-9ea5-4d2b-8d50-3695e5657d24", "AQAAAAIAAYagAAAAEGd0XW3/mnJLe0u6b0mhvaIo/+8P6KtARSyClS7wHZ+MhHYQhc77koudANQ6I5Lc0Q==", "7d8c9c0a-40c1-4b2f-8b44-aee0f6cdddc5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "students");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 12:02:30");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b705d8c-9192-4498-9211-4effee23c143", "AQAAAAIAAYagAAAAEGzvg6cUv0llBkHB2sB9RLlLAo+ORra07+e2XqKLhEi4jiz0U4ie+4r1KWlteo34cw==", "3c43151e-237f-49cc-ad2c-c982677b7a23" });
        }
    }
}
