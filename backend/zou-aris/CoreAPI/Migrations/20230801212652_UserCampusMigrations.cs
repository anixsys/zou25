using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserCampusMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_campuses_users_UserId",
                table: "campuses");

            migrationBuilder.DropIndex(
                name: "IX_campuses_UserId",
                table: "campuses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "campuses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "1/8/2023 23:26:52");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97d07894-afa1-4aa9-9bae-43b1420549d6", "AQAAAAIAAYagAAAAEHz7UTmE8O6Fo4tL29l+/f/+glI6iPOcn/387BKUQb+wUmOuRr9nJEhbKhujfFa3/w==", "d4b7a960-b1e3-4867-ba7a-10d953cf16db" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "campuses",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "31/7/2023 10:40:03");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "477f4eba-b504-40b6-9033-0d7ace018475", "AQAAAAIAAYagAAAAEBnTXFZ1ZfJZP722HZFLZizuSrnnvqC0jdKCi/0jM/ki+/GPZw+xJPT/Vyv6TXWPzQ==", "55b15934-1f6c-4cac-af9a-84664b5c7415" });

            migrationBuilder.CreateIndex(
                name: "IX_campuses_UserId",
                table: "campuses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_campuses_users_UserId",
                table: "campuses",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
