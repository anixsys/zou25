using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserDepartmentMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_users_UserId",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_UserId",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "departments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "1/8/2023 23:30:43");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70529934-9159-4aba-8b75-114b179acb3d", "AQAAAAIAAYagAAAAEO0pGB/PfwwPDbLLpdXqqpcD/68jbHC1ezLrc7m7OQWMec/lLQPwmnZh41SPpb9bEA==", "e432844b-d2d0-4cdf-bf73-b3ec64fd6a1e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "departments",
                type: "text",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_departments_UserId",
                table: "departments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_users_UserId",
                table: "departments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
