using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class CourseOnOfferMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courseOnOfferTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false, defaultValue: "PENDING"),
                    Inititateby = table.Column<int>(type: "integer", nullable: false),
                    ApprovedBy = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseOnOfferTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "courseOnOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseOnOfferTemplateId = table.Column<int>(type: "integer", nullable: false),
                    ProgrammeId = table.Column<int>(type: "integer", nullable: false),
                    AttendenceTypeId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Semester = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseOnOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courseOnOffers_courseOnOfferTemplates_CourseOnOfferTemplate~",
                        column: x => x.CourseOnOfferTemplateId,
                        principalTable: "courseOnOfferTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courseOnOffers_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_courseOnOffers_CourseId",
                table: "courseOnOffers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_courseOnOffers_CourseOnOfferTemplateId",
                table: "courseOnOffers",
                column: "CourseOnOfferTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courseOnOffers");

            migrationBuilder.DropTable(
                name: "courseOnOfferTemplates");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "5/8/2023 20:15:33");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2da9daa-c511-40ef-8b9a-064abf40fdf9", "AQAAAAIAAYagAAAAEDUFtDCbIg1Y18hjc+Q0C6w/0xu8igy6t28T2eXpPgYkKSw40Zb/Ru3uvcwMvuoDfw==", "f92455cd-428c-4887-b6bf-1b3b1fd83613" });
        }
    }
}
