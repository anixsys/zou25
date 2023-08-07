using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class StudentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pin = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Profile = table.Column<string>(type: "text", nullable: true),
                    Dob = table.Column<string>(type: "text", nullable: false),
                    Intake = table.Column<string>(type: "text", nullable: true),
                    Pushed = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentContacts_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentKins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentKins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentKins_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentProgrammes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    ProgrammeId = table.Column<int>(type: "integer", nullable: false),
                    AcademicRegulationId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false, defaultValue: "PENDING"),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentProgrammes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentProgrammes_academicregulations_AcademicRegulationId",
                        column: x => x.AcademicRegulationId,
                        principalTable: "academicregulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentProgrammes_programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentProgrammes_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aa7b86-508c-4666-8bd8-0631e84e2082",
                column: "ConcurrencyStamp",
                value: "3/8/2023 22:18:43");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: "fe0773fe-8685-420c-837f-c6222de3ba2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c11f651-8de6-4e7e-b4f9-ec3d83f4ef2c", "AQAAAAIAAYagAAAAEBiEbYUFgo028WaHH01JqiASPLrxh7znUS+AmoJj1kw1JHL4TZjcVI8tLXADphXnjw==", "fa5eb648-0277-4930-88a9-1c5ac86dadca" });

            migrationBuilder.CreateIndex(
                name: "IX_studentContacts_StudentId",
                table: "studentContacts",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentKins_StudentId",
                table: "studentKins",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentProgrammes_AcademicRegulationId",
                table: "studentProgrammes",
                column: "AcademicRegulationId");

            migrationBuilder.CreateIndex(
                name: "IX_studentProgrammes_ProgrammeId",
                table: "studentProgrammes",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_studentProgrammes_StudentId",
                table: "studentProgrammes",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentContacts");

            migrationBuilder.DropTable(
                name: "studentKins");

            migrationBuilder.DropTable(
                name: "studentProgrammes");

            migrationBuilder.DropTable(
                name: "students");

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
        }
    }
}
