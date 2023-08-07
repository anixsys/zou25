using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantStudentNumberMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdmissionSessionId",
                table: "applicantstudentnumbers",
                type: "integer",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_applicantstudentnumbers_AdmissionSessionId",
                table: "applicantstudentnumbers",
                column: "AdmissionSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_applicantstudentnumbers_admissionsessions_AdmissionSessionId",
                table: "applicantstudentnumbers",
                column: "AdmissionSessionId",
                principalTable: "admissionsessions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applicantstudentnumbers_admissionsessions_AdmissionSessionId",
                table: "applicantstudentnumbers");

            migrationBuilder.DropIndex(
                name: "IX_applicantstudentnumbers_AdmissionSessionId",
                table: "applicantstudentnumbers");

            migrationBuilder.DropColumn(
                name: "AdmissionSessionId",
                table: "applicantstudentnumbers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "3/8/2023 19:14:19");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89de9e47-775d-4cb8-9068-0e6963a21c5d", "AQAAAAIAAYagAAAAEKgV9OBr1I+aNESVfHXboMoFKAigMBFIFDSkTcKUlaqD9MH2Z7/rpgYM0xVrgCDMeg==", "c72eb98e-0c70-4465-a3f1-7d751d1d957f" });
        }
    }
}
