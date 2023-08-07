using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantStudentNumberMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "applicationId",
                table: "applicantstudentnumbers",
                type: "integer",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_applicantstudentnumbers_applicationId",
                table: "applicantstudentnumbers",
                column: "applicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_applicantstudentnumbers_applications_applicationId",
                table: "applicantstudentnumbers",
                column: "applicationId",
                principalTable: "applications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applicantstudentnumbers_applications_applicationId",
                table: "applicantstudentnumbers");

            migrationBuilder.DropIndex(
                name: "IX_applicantstudentnumbers_applicationId",
                table: "applicantstudentnumbers");

            migrationBuilder.DropColumn(
                name: "applicationId",
                table: "applicantstudentnumbers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "3/8/2023 19:26:29");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "828c233c-7c21-4fba-ae2b-434f26c012e3", "AQAAAAIAAYagAAAAEKCRWKygOaPdPUNjCoQ2tu1AmRWMNbWAZmDUuhNsBQ1QnayMoKorTdOI9MYfnlRH0g==", "c58e58b6-50bc-4c05-bbcd-31bcf9232468" });
        }
    }
}
