using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class StudentIdentificationNumberMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CampusId",
                table: "students",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 12:36:40");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b3694a4-420c-4a20-80d5-17077d7346d9", "AQAAAAIAAYagAAAAEBaGsSbhi/tM6s6UNRHBOP7Ue094BcmOxCsIBL7YAXSsBLx+erD3f6mXTXM5s4RQMw==", "da076331-bef3-475d-ad85-929f6c8f3b33" });

            migrationBuilder.CreateIndex(
                name: "IX_students_CampusId",
                table: "students",
                column: "CampusId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_campuses_CampusId",
                table: "students",
                column: "CampusId",
                principalTable: "campuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_campuses_CampusId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_CampusId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "CampusId",
                table: "students");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
