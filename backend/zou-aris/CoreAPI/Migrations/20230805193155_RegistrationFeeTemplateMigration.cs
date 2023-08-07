using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class RegistrationFeeTemplateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InitiatedBy",
                table: "registrationFeeTemplates",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "registrationFeeTemplates",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "registrationFeeTemplates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 21:31:55");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24484d93-4079-439e-b6db-817b0ec1208e", "AQAAAAIAAYagAAAAEBeZ7K9trK/mepINaJSx5I/D8zqKqn2PNpYKmbvCUJs4f+Mgcow4Q1c1Qbz5mZq5cw==", "d3a5b4c1-6418-495e-94ac-a1bfeae26d9b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "registrationFeeTemplates");

            migrationBuilder.AlterColumn<int>(
                name: "InitiatedBy",
                table: "registrationFeeTemplates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedBy",
                table: "registrationFeeTemplates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 20:47:14");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9caa6754-50b8-4f88-beae-cfe9e7216cc4", "AQAAAAIAAYagAAAAEKXvv3cYd3ROpk1x+wdfZgvgcAg5Nlxg3SMF5Ubfb/2ID4kkDsKMQh/1P8vf/OVkkw==", "30d90496-9284-46a9-9d40-c622e14d62b9" });
        }
    }
}
