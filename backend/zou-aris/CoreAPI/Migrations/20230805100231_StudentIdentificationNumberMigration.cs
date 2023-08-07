using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class StudentIdentificationNumberMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificationnumber",
                table: "students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Identificationtype",
                table: "students",
                type: "text",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificationnumber",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Identificationtype",
                table: "students");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 11:38:07");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8156ca08-1ecc-4371-9a78-95b3dc31a251", "AQAAAAIAAYagAAAAEDqfrv9oKvyr5Up33f/3gkExDDcrSEYNQ70FrqsTDDz84rvCxVb6tr9po+5Ef7bN/g==", "551d55ba-e018-413e-996a-d235f048533b" });
        }
    }
}
