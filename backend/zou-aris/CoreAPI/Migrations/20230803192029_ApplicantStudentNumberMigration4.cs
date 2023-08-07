using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantStudentNumberMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "applicantstudentnumbers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "3/8/2023 21:20:28");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2ca22b2-b205-4ed2-aa01-b054247e4449", "AQAAAAIAAYagAAAAEPeQzZXSHS4p/rB0ZL4jE7HAhb9VDkd+a0ZG+OaLyX/3PPi5vf+ApqmhYA9prKkPnA==", "91834183-7772-401b-8a11-955c37a5ec3f" });

            migrationBuilder.CreateIndex(
                name: "IX_applicantstudentnumbers_UserId",
                table: "applicantstudentnumbers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_applicantstudentnumbers_users_UserId",
                table: "applicantstudentnumbers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applicantstudentnumbers_users_UserId",
                table: "applicantstudentnumbers");

            migrationBuilder.DropIndex(
                name: "IX_applicantstudentnumbers_UserId",
                table: "applicantstudentnumbers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "applicantstudentnumbers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "3/8/2023 19:42:47");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17a4ce84-5fd9-4045-8260-2ea1e95d0628", "AQAAAAIAAYagAAAAEMRc3u7SLpdEn/FMD4pEwAiGxMQeVgnBkImF18r1B/yk3s8coYJGCX1ByBogPglaLA==", "23bc6120-d1b8-4d01-bb14-fef9c9a1afa4" });
        }
    }
}
