using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class FullNameMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "students",
                type: "text",
                nullable: false,
                computedColumnSql: "\"Name\" || ' ' || \"Surname\"",
                stored: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "applicants",
                type: "text",
                nullable: false,
                computedColumnSql: "\"Name\" || ' ' || \"Surname\"",
                stored: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "students");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "applicants");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "3/8/2023 23:41:09");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c71eae61-cdf3-49f3-90b0-ad7b677957d9", "AQAAAAIAAYagAAAAEJJisdPXdB9Kb5O3nf1AZnX4XCTKTF2UYjkYzFgLxcwjaXPxc93Ku5fOIIInieggmg==", "94794997-37bd-48b7-986b-ca6a9d53e474" });
        }
    }
}
