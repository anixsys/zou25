using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class RegistrationFeeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InitiatedBy",
                table: "registrationFees",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "registrationFees",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 22:14:23");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81b4e571-f1de-4420-89e7-dcdb181a5bf9", "AQAAAAIAAYagAAAAEB70ZXkd3sitpco+jlmboHM3BBp+upWmvEnVSrEy5YzXECdAaUy4tI5u8nXU/f45OQ==", "5e0db723-3a29-4534-8c93-48115736d52e" });

            migrationBuilder.CreateIndex(
                name: "IX_registrationFees_ApplicantTypeId",
                table: "registrationFees",
                column: "ApplicantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_registrationFees_CurrencyId",
                table: "registrationFees",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_registrationFees_FacultyId",
                table: "registrationFees",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_registrationFees_ProgrammeTypeId",
                table: "registrationFees",
                column: "ProgrammeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_registrationFees_applicanttypes_ApplicantTypeId",
                table: "registrationFees",
                column: "ApplicantTypeId",
                principalTable: "applicanttypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_registrationFees_currency_CurrencyId",
                table: "registrationFees",
                column: "CurrencyId",
                principalTable: "currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_registrationFees_faculties_FacultyId",
                table: "registrationFees",
                column: "FacultyId",
                principalTable: "faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_registrationFees_programmetypes_ProgrammeTypeId",
                table: "registrationFees",
                column: "ProgrammeTypeId",
                principalTable: "programmetypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registrationFees_applicanttypes_ApplicantTypeId",
                table: "registrationFees");

            migrationBuilder.DropForeignKey(
                name: "FK_registrationFees_currency_CurrencyId",
                table: "registrationFees");

            migrationBuilder.DropForeignKey(
                name: "FK_registrationFees_faculties_FacultyId",
                table: "registrationFees");

            migrationBuilder.DropForeignKey(
                name: "FK_registrationFees_programmetypes_ProgrammeTypeId",
                table: "registrationFees");

            migrationBuilder.DropIndex(
                name: "IX_registrationFees_ApplicantTypeId",
                table: "registrationFees");

            migrationBuilder.DropIndex(
                name: "IX_registrationFees_CurrencyId",
                table: "registrationFees");

            migrationBuilder.DropIndex(
                name: "IX_registrationFees_FacultyId",
                table: "registrationFees");

            migrationBuilder.DropIndex(
                name: "IX_registrationFees_ProgrammeTypeId",
                table: "registrationFees");

            migrationBuilder.AlterColumn<int>(
                name: "InitiatedBy",
                table: "registrationFees",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedBy",
                table: "registrationFees",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 22:02:47");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fecc604-da77-4bb0-a56d-e5fbcd6ae6a9", "AQAAAAIAAYagAAAAEFnK7Ee+hNn89md+LJBSoRwWlhi+kLW8Q04kwHmzAnNr6ysZ9eFbK87Un2adpaAgnQ==", "9bee14cf-6485-43c6-ac96-be12369752a8" });
        }
    }
}
