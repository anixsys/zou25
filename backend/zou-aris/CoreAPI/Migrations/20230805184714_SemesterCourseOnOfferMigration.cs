using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class SemesterCourseOnOfferMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "courseOnOfferTemplates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "semesterCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SemesteId = table.Column<int>(type: "integer", nullable: false),
                    CourseOnOfferTemplateId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semesterCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_semesterCourses_courseOnOfferTemplates_CourseOnOfferTemplat~",
                        column: x => x.CourseOnOfferTemplateId,
                        principalTable: "courseOnOfferTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_courseOnOfferTemplates_DepartmentId",
                table: "courseOnOfferTemplates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_semesterCourses_CourseOnOfferTemplateId",
                table: "semesterCourses",
                column: "CourseOnOfferTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_courseOnOfferTemplates_departments_DepartmentId",
                table: "courseOnOfferTemplates",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courseOnOfferTemplates_departments_DepartmentId",
                table: "courseOnOfferTemplates");

            migrationBuilder.DropTable(
                name: "semesterCourses");

            migrationBuilder.DropIndex(
                name: "IX_courseOnOfferTemplates_DepartmentId",
                table: "courseOnOfferTemplates");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "courseOnOfferTemplates");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 20:37:16");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72a688f4-98fa-4408-a055-bdcbdcec3667", "AQAAAAIAAYagAAAAEGfwvgd6JTVGl4JPQqiMZoTEK+H21PkTiKy9Wdm0Imscp/n4fRzkDnufA+NcAWBBjQ==", "a31097ba-7057-405d-94b4-3a6ff9628253" });
        }
    }
}
