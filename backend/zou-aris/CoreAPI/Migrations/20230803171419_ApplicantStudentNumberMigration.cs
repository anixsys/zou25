using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantStudentNumberMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocVerified",
                table: "applicantstudentnumbers",
                type: "text",
                nullable: true,
                defaultValue: "N");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocVerified",
                table: "applicantstudentnumbers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "3/8/2023 10:55:17");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99fc9538-269a-4a29-b85f-00c96d5a0de0", "AQAAAAIAAYagAAAAEJU154IhflBPgCnLjEI0wXUR6LBT+WHTuiYws3eVEWLnag6eYLwBG8oLnH5jgnklaQ==", "6983604b-980c-4ac1-8ec7-52cd7bbbd95b" });
        }
    }
}
