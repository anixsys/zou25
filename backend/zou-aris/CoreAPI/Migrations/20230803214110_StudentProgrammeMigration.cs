using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class StudentProgrammeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendenceTypeId",
                table: "studentProgrammes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_studentProgrammes_AttendenceTypeId",
                table: "studentProgrammes",
                column: "AttendenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentProgrammes_attendencetypes_AttendenceTypeId",
                table: "studentProgrammes",
                column: "AttendenceTypeId",
                principalTable: "attendencetypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentProgrammes_attendencetypes_AttendenceTypeId",
                table: "studentProgrammes");

            migrationBuilder.DropIndex(
                name: "IX_studentProgrammes_AttendenceTypeId",
                table: "studentProgrammes");

            migrationBuilder.DropColumn(
                name: "AttendenceTypeId",
                table: "studentProgrammes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "3/8/2023 22:18:43");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c11f651-8de6-4e7e-b4f9-ec3d83f4ef2c", "AQAAAAIAAYagAAAAEBiEbYUFgo028WaHH01JqiASPLrxh7znUS+AmoJj1kw1JHL4TZjcVI8tLXADphXnjw==", "fa5eb648-0277-4930-88a9-1c5ac86dadca" });
        }
    }
}
