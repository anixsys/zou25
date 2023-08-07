using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class AllMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolesystemmodules_systemmodules_SystemmoduleId",
                table: "rolesystemmodules");

            migrationBuilder.DropForeignKey(
                name: "FK_systemsubmodules_systemmodules_SystemmoduleId",
                table: "systemsubmodules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "auditEntries");

            migrationBuilder.RenameColumn(
                name: "SystemmoduleId",
                table: "systemsubmodules",
                newName: "SystemModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_systemsubmodules_SystemmoduleId",
                table: "systemsubmodules",
                newName: "IX_systemsubmodules_SystemModuleId");

            migrationBuilder.RenameColumn(
                name: "SystemmoduleId",
                table: "rolesystemmodules",
                newName: "SystemModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_rolesystemmodules_SystemmoduleId",
                table: "rolesystemmodules",
                newName: "IX_rolesystemmodules_SystemModuleId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "auditEntries",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "campuses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "EntityId",
                table: "auditEntries",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "auditEntries",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "admissionfeetemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admissionfeetemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admissionsessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<string>(type: "text", nullable: true),
                    EndDate = table.Column<string>(type: "text", nullable: true),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admissionsessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Phonenumber = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    MaritalStatus = table.Column<string>(type: "text", nullable: false),
                    Maidenname = table.Column<string>(type: "text", nullable: false),
                    DOB = table.Column<string>(type: "text", nullable: false),
                    IdentificationType = table.Column<string>(type: "text", nullable: false),
                    identification = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "applicanttypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicanttypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "attendencetypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendencetypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emailqueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    BodyHtml = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailqueues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "entrymodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrymodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "globalsettingtemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    decisiontype = table.Column<string>(type: "text", nullable: true),
                    semesters = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_globalsettingtemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "programmetypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programmetypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tokeninfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokeninfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usercampuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CampusId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usercampuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usercampuses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usercampuses_campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "campuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "admissionsessiontemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdmissionSessionId = table.Column<int>(type: "integer", nullable: false),
                    AdmissionTemplateId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admissionsessiontemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_admissionsessiontemplates_admissionsessions_AdmissionSessio~",
                        column: x => x.AdmissionSessionId,
                        principalTable: "admissionsessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applicantotherqualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    applicantId = table.Column<int>(type: "integer", nullable: false),
                    institution = table.Column<string>(type: "text", nullable: false),
                    qualification = table.Column<string>(type: "text", nullable: false),
                    year = table.Column<string>(type: "text", nullable: false),
                    grade = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicantotherqualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicantotherqualifications_applicants_applicantId",
                        column: x => x.applicantId,
                        principalTable: "applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applicantstudentnumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    applicantId = table.Column<int>(type: "integer", nullable: false),
                    nationalId = table.Column<string>(type: "text", nullable: false),
                    studentnumber = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicantstudentnumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicantstudentnumbers_applicants_applicantId",
                        column: x => x.applicantId,
                        principalTable: "applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applicantworkexperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    applicantId = table.Column<int>(type: "integer", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: false),
                    Jobtitle = table.Column<string>(type: "text", nullable: false),
                    duration = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicantworkexperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicantworkexperiences_applicants_applicantId",
                        column: x => x.applicantId,
                        principalTable: "applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entrymoderequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EntryModeId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrymoderequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_entrymoderequirements_entrymodes_EntryModeId",
                        column: x => x.EntryModeId,
                        principalTable: "entrymodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FacultyId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departments_faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "admissiondocuments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicantTypeId = table.Column<int>(type: "integer", nullable: false),
                    ProgrammetypeId = table.Column<int>(type: "integer", nullable: false),
                    DocumentId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admissiondocuments", x => x.id);
                    table.ForeignKey(
                        name: "FK_admissiondocuments_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_admissiondocuments_applicanttypes_ApplicantTypeId",
                        column: x => x.ApplicantTypeId,
                        principalTable: "applicanttypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_admissiondocuments_programmetypes_ProgrammetypeId",
                        column: x => x.ProgrammetypeId,
                        principalTable: "programmetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "admissionfees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdmissionFeeTemplateId = table.Column<int>(type: "integer", nullable: false),
                    ApplicanttypeId = table.Column<int>(type: "integer", nullable: false),
                    ProgrammeTypeId = table.Column<int>(type: "integer", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admissionfees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_admissionfees_admissionfeetemplates_AdmissionFeeTemplateId",
                        column: x => x.AdmissionFeeTemplateId,
                        principalTable: "admissionfeetemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_admissionfees_applicanttypes_ApplicanttypeId",
                        column: x => x.ApplicanttypeId,
                        principalTable: "applicanttypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_admissionfees_currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_admissionfees_programmetypes_ProgrammeTypeId",
                        column: x => x.ProgrammeTypeId,
                        principalTable: "programmetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "admissiontemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProgrammetypeId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admissiontemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_admissiontemplates_programmetypes_ProgrammetypeId",
                        column: x => x.ProgrammetypeId,
                        principalTable: "programmetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    applicantId = table.Column<int>(type: "integer", nullable: false),
                    uuid = table.Column<string>(type: "text", nullable: false),
                    AppNumber = table.Column<string>(type: "text", nullable: false),
                    AdmissionSessionId = table.Column<int>(type: "integer", nullable: false),
                    ApplicanttypeId = table.Column<int>(type: "integer", nullable: false),
                    CampusId = table.Column<int>(type: "integer", nullable: false),
                    ProgrammeTypeId = table.Column<int>(type: "integer", nullable: false),
                    PaymentStatus = table.Column<string>(type: "text", nullable: true),
                    ApprovalStatus = table.Column<string>(type: "text", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true),
                    DocumentVerification = table.Column<string>(type: "text", nullable: true),
                    attendencetypeId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    EntryModeId = table.Column<int>(type: "integer", nullable: false),
                    Pushed = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_applications_admissionsessions_AdmissionSessionId",
                        column: x => x.AdmissionSessionId,
                        principalTable: "admissionsessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applications_applicants_applicantId",
                        column: x => x.applicantId,
                        principalTable: "applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applications_applicanttypes_ApplicanttypeId",
                        column: x => x.ApplicanttypeId,
                        principalTable: "applicanttypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applications_attendencetypes_attendencetypeId",
                        column: x => x.attendencetypeId,
                        principalTable: "attendencetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applications_campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "campuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applications_entrymodes_EntryModeId",
                        column: x => x.EntryModeId,
                        principalTable: "entrymodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applications_programmetypes_ProgrammeTypeId",
                        column: x => x.ProgrammeTypeId,
                        principalTable: "programmetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generalregulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    ProgrammetypeId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    GlobalsettingtemplateId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generalregulations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_generalregulations_globalsettingtemplate_Globalsettingtempl~",
                        column: x => x.GlobalsettingtemplateId,
                        principalTable: "globalsettingtemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_generalregulations_programmetypes_ProgrammetypeId",
                        column: x => x.ProgrammetypeId,
                        principalTable: "programmetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applicantsubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    applicantId = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    level = table.Column<string>(type: "text", nullable: false),
                    grade = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicantsubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicantsubjects_applicants_applicantId",
                        column: x => x.applicantId,
                        principalTable: "applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applicantsubjects_subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courses_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "programmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ProgrammeTypeId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_programmes_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_programmes_programmetypes_ProgrammeTypeId",
                        column: x => x.ProgrammeTypeId,
                        principalTable: "programmetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userdepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userdepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userdepartments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userdepartments_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applicantdocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    admissiondocumentId = table.Column<int>(type: "integer", nullable: false),
                    applicantId = table.Column<int>(type: "integer", nullable: false),
                    filename = table.Column<string>(type: "text", nullable: false),
                    Verified = table.Column<string>(type: "text", nullable: true),
                    VerifiedBy = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicantdocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicantdocuments_admissiondocuments_admissiondocumentId",
                        column: x => x.admissiondocumentId,
                        principalTable: "admissiondocuments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applicantdocuments_applicants_applicantId",
                        column: x => x.applicantId,
                        principalTable: "applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applicationentrymodedocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false),
                    EntryModeRequirementId = table.Column<int>(type: "integer", nullable: false),
                    filename = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationentrymodedocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicationentrymodedocuments_applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applicationentrymodedocuments_entrymoderequirements_EntryMo~",
                        column: x => x.EntryModeRequirementId,
                        principalTable: "entrymoderequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applicationpayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<string>(type: "text", nullable: false),
                    applicationId = table.Column<int>(type: "integer", nullable: false),
                    applicantId = table.Column<int>(type: "integer", nullable: false),
                    admissionsessionId = table.Column<int>(type: "integer", nullable: false),
                    pollUrl = table.Column<string>(type: "text", nullable: true),
                    currency = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    referencenumber = table.Column<string>(type: "text", nullable: true),
                    paymentmethod = table.Column<string>(type: "text", nullable: false),
                    administratorId = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationpayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicationpayments_admissionsessions_admissionsessionId",
                        column: x => x.admissionsessionId,
                        principalTable: "admissionsessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applicationpayments_applicants_applicantId",
                        column: x => x.applicantId,
                        principalTable: "applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applicationpayments_applications_applicationId",
                        column: x => x.applicationId,
                        principalTable: "applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generalregulationacademicrules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GeneralregulationId = table.Column<int>(type: "integer", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    semester = table.Column<int>(type: "integer", nullable: false),
                    requiredlevel = table.Column<int>(type: "integer", nullable: true),
                    requiredsemester = table.Column<int>(type: "integer", nullable: true),
                    corepercentage = table.Column<int>(type: "integer", nullable: false),
                    electivepercentage = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generalregulationacademicrules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_generalregulationacademicrules_generalregulations_Generalre~",
                        column: x => x.GeneralregulationId,
                        principalTable: "generalregulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generalregulationregistrationrules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GeneralregulationId = table.Column<int>(type: "integer", nullable: false),
                    maximumcourses = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generalregulationregistrationrules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_generalregulationregistrationrules_generalregulations_Gener~",
                        column: x => x.GeneralregulationId,
                        principalTable: "generalregulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academicregulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProgrammeId = table.Column<int>(type: "integer", nullable: false),
                    AttendencetypeId = table.Column<int>(type: "integer", nullable: false),
                    ProgrammeTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    GeneralregulationId = table.Column<int>(type: "integer", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    MaximumYears = table.Column<int>(type: "integer", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academicregulations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_academicregulations_attendencetypes_AttendencetypeId",
                        column: x => x.AttendencetypeId,
                        principalTable: "attendencetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_academicregulations_programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_academicregulations_programmetypes_ProgrammeTypeId",
                        column: x => x.ProgrammeTypeId,
                        principalTable: "programmetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "admissionprogrammes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProgrammeId = table.Column<int>(type: "integer", nullable: false),
                    AdmissionTemplateId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admissionprogrammes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_admissionprogrammes_admissiontemplates_AdmissionTemplateId",
                        column: x => x.AdmissionTemplateId,
                        principalTable: "admissiontemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_admissionprogrammes_programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applicationprogrammes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    applicationId = table.Column<int>(type: "integer", nullable: false),
                    ProgrammeId = table.Column<int>(type: "integer", nullable: false),
                    AttendenceTypeId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationprogrammes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicationprogrammes_applications_applicationId",
                        column: x => x.applicationId,
                        principalTable: "applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applicationprogrammes_attendencetypes_AttendenceTypeId",
                        column: x => x.AttendenceTypeId,
                        principalTable: "attendencetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applicationprogrammes_programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "programmehistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProgrammeId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programmehistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_programmehistory_programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "programmespecializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProgrammeId = table.Column<int>(type: "integer", nullable: false),
                    Area = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programmespecializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_programmespecializations_programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academicregulationparameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademicRegulationId = table.Column<int>(type: "integer", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    semester = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    CourseType = table.Column<string>(type: "text", nullable: false),
                    ExamContribution = table.Column<int>(type: "integer", nullable: false),
                    CourseworkContribution = table.Column<int>(type: "integer", nullable: false),
                    CourseWeight = table.Column<int>(type: "integer", nullable: false),
                    CourseTake = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academicregulationparameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_academicregulationparameters_academicregulations_AcademicRe~",
                        column: x => x.AcademicRegulationId,
                        principalTable: "academicregulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_academicregulationparameters_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "admissionattendencetypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdmissionprogrammeId = table.Column<int>(type: "integer", nullable: false),
                    AttendencetypeId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admissionattendencetypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_admissionattendencetypes_admissionprogrammes_Admissionprogr~",
                        column: x => x.AdmissionprogrammeId,
                        principalTable: "admissionprogrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_admissionattendencetypes_attendencetypes_AttendencetypeId",
                        column: x => x.AttendencetypeId,
                        principalTable: "attendencetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alternatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademicregulationparameterId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alternatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alternatives_academicregulationparameters_Academicregulatio~",
                        column: x => x.AcademicregulationparameterId,
                        principalTable: "academicregulationparameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alternatives_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prerequisites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademicregulationparameterId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prerequisites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prerequisites_academicregulationparameters_Academicregulati~",
                        column: x => x.AcademicregulationparameterId,
                        principalTable: "academicregulationparameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prerequisites_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_academicregulationparameters_AcademicRegulationId",
                table: "academicregulationparameters",
                column: "AcademicRegulationId");

            migrationBuilder.CreateIndex(
                name: "IX_academicregulationparameters_CourseId",
                table: "academicregulationparameters",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_academicregulations_AttendencetypeId",
                table: "academicregulations",
                column: "AttendencetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_academicregulations_ProgrammeId",
                table: "academicregulations",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_academicregulations_ProgrammeTypeId",
                table: "academicregulations",
                column: "ProgrammeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_admissionattendencetypes_AdmissionprogrammeId",
                table: "admissionattendencetypes",
                column: "AdmissionprogrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_admissionattendencetypes_AttendencetypeId",
                table: "admissionattendencetypes",
                column: "AttendencetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_admissiondocuments_ApplicantTypeId",
                table: "admissiondocuments",
                column: "ApplicantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_admissiondocuments_DocumentId",
                table: "admissiondocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_admissiondocuments_ProgrammetypeId",
                table: "admissiondocuments",
                column: "ProgrammetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_admissionfees_AdmissionFeeTemplateId",
                table: "admissionfees",
                column: "AdmissionFeeTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_admissionfees_ApplicanttypeId",
                table: "admissionfees",
                column: "ApplicanttypeId");

            migrationBuilder.CreateIndex(
                name: "IX_admissionfees_CurrencyId",
                table: "admissionfees",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_admissionfees_ProgrammeTypeId",
                table: "admissionfees",
                column: "ProgrammeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_admissionprogrammes_AdmissionTemplateId",
                table: "admissionprogrammes",
                column: "AdmissionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_admissionprogrammes_ProgrammeId",
                table: "admissionprogrammes",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_admissionsessiontemplates_AdmissionSessionId",
                table: "admissionsessiontemplates",
                column: "AdmissionSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_admissiontemplates_ProgrammetypeId",
                table: "admissiontemplates",
                column: "ProgrammetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_alternatives_AcademicregulationparameterId",
                table: "alternatives",
                column: "AcademicregulationparameterId");

            migrationBuilder.CreateIndex(
                name: "IX_alternatives_CourseId",
                table: "alternatives",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_applicantdocuments_admissiondocumentId",
                table: "applicantdocuments",
                column: "admissiondocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_applicantdocuments_applicantId",
                table: "applicantdocuments",
                column: "applicantId");

            migrationBuilder.CreateIndex(
                name: "IX_applicantotherqualifications_applicantId",
                table: "applicantotherqualifications",
                column: "applicantId");

            migrationBuilder.CreateIndex(
                name: "IX_applicantstudentnumbers_applicantId",
                table: "applicantstudentnumbers",
                column: "applicantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_applicantsubjects_applicantId",
                table: "applicantsubjects",
                column: "applicantId");

            migrationBuilder.CreateIndex(
                name: "IX_applicantsubjects_SubjectId",
                table: "applicantsubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_applicantworkexperiences_applicantId",
                table: "applicantworkexperiences",
                column: "applicantId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationentrymodedocuments_ApplicationId",
                table: "applicationentrymodedocuments",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationentrymodedocuments_EntryModeRequirementId",
                table: "applicationentrymodedocuments",
                column: "EntryModeRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationpayments_admissionsessionId",
                table: "applicationpayments",
                column: "admissionsessionId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationpayments_applicantId",
                table: "applicationpayments",
                column: "applicantId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationpayments_applicationId",
                table: "applicationpayments",
                column: "applicationId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationprogrammes_applicationId",
                table: "applicationprogrammes",
                column: "applicationId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationprogrammes_AttendenceTypeId",
                table: "applicationprogrammes",
                column: "AttendenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationprogrammes_ProgrammeId",
                table: "applicationprogrammes",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_applications_AdmissionSessionId",
                table: "applications",
                column: "AdmissionSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_applications_applicantId",
                table: "applications",
                column: "applicantId");

            migrationBuilder.CreateIndex(
                name: "IX_applications_ApplicanttypeId",
                table: "applications",
                column: "ApplicanttypeId");

            migrationBuilder.CreateIndex(
                name: "IX_applications_attendencetypeId",
                table: "applications",
                column: "attendencetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_applications_CampusId",
                table: "applications",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_applications_EntryModeId",
                table: "applications",
                column: "EntryModeId");

            migrationBuilder.CreateIndex(
                name: "IX_applications_ProgrammeTypeId",
                table: "applications",
                column: "ProgrammeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_applications_UserId",
                table: "applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_DepartmentId",
                table: "courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_departments_FacultyId",
                table: "departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_entrymoderequirements_EntryModeId",
                table: "entrymoderequirements",
                column: "EntryModeId");

            migrationBuilder.CreateIndex(
                name: "IX_generalregulationacademicrules_GeneralregulationId",
                table: "generalregulationacademicrules",
                column: "GeneralregulationId");

            migrationBuilder.CreateIndex(
                name: "IX_generalregulationregistrationrules_GeneralregulationId",
                table: "generalregulationregistrationrules",
                column: "GeneralregulationId");

            migrationBuilder.CreateIndex(
                name: "IX_generalregulations_GlobalsettingtemplateId",
                table: "generalregulations",
                column: "GlobalsettingtemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_generalregulations_ProgrammetypeId",
                table: "generalregulations",
                column: "ProgrammetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_prerequisites_AcademicregulationparameterId",
                table: "prerequisites",
                column: "AcademicregulationparameterId");

            migrationBuilder.CreateIndex(
                name: "IX_prerequisites_CourseId",
                table: "prerequisites",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_programmehistory_ProgrammeId",
                table: "programmehistory",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_programmes_DepartmentId",
                table: "programmes",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_programmes_ProgrammeTypeId",
                table: "programmes",
                column: "ProgrammeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_programmespecializations_ProgrammeId",
                table: "programmespecializations",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_usercampuses_CampusId",
                table: "usercampuses",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_usercampuses_UserId",
                table: "usercampuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userdepartments_DepartmentId",
                table: "userdepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_userdepartments_UserId",
                table: "userdepartments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_rolesystemmodules_systemmodules_SystemModuleId",
                table: "rolesystemmodules",
                column: "SystemModuleId",
                principalTable: "systemmodules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_systemsubmodules_systemmodules_SystemModuleId",
                table: "systemsubmodules",
                column: "SystemModuleId",
                principalTable: "systemmodules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolesystemmodules_systemmodules_SystemModuleId",
                table: "rolesystemmodules");

            migrationBuilder.DropForeignKey(
                name: "FK_systemsubmodules_systemmodules_SystemModuleId",
                table: "systemsubmodules");

            migrationBuilder.DropTable(
                name: "admissionattendencetypes");

            migrationBuilder.DropTable(
                name: "admissionfees");

            migrationBuilder.DropTable(
                name: "admissionsessiontemplates");

            migrationBuilder.DropTable(
                name: "alternatives");

            migrationBuilder.DropTable(
                name: "applicantdocuments");

            migrationBuilder.DropTable(
                name: "applicantotherqualifications");

            migrationBuilder.DropTable(
                name: "applicantstudentnumbers");

            migrationBuilder.DropTable(
                name: "applicantsubjects");

            migrationBuilder.DropTable(
                name: "applicantworkexperiences");

            migrationBuilder.DropTable(
                name: "applicationentrymodedocuments");

            migrationBuilder.DropTable(
                name: "applicationpayments");

            migrationBuilder.DropTable(
                name: "applicationprogrammes");

            migrationBuilder.DropTable(
                name: "emailqueues");

            migrationBuilder.DropTable(
                name: "generalregulationacademicrules");

            migrationBuilder.DropTable(
                name: "generalregulationregistrationrules");

            migrationBuilder.DropTable(
                name: "prerequisites");

            migrationBuilder.DropTable(
                name: "programmehistory");

            migrationBuilder.DropTable(
                name: "programmespecializations");

            migrationBuilder.DropTable(
                name: "tokeninfo");

            migrationBuilder.DropTable(
                name: "usercampuses");

            migrationBuilder.DropTable(
                name: "userdepartments");

            migrationBuilder.DropTable(
                name: "admissionprogrammes");

            migrationBuilder.DropTable(
                name: "admissionfeetemplates");

            migrationBuilder.DropTable(
                name: "currency");

            migrationBuilder.DropTable(
                name: "admissiondocuments");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "entrymoderequirements");

            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DropTable(
                name: "generalregulations");

            migrationBuilder.DropTable(
                name: "academicregulationparameters");

            migrationBuilder.DropTable(
                name: "admissiontemplates");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "admissionsessions");

            migrationBuilder.DropTable(
                name: "applicants");

            migrationBuilder.DropTable(
                name: "applicanttypes");

            migrationBuilder.DropTable(
                name: "entrymodes");

            migrationBuilder.DropTable(
                name: "globalsettingtemplate");

            migrationBuilder.DropTable(
                name: "academicregulations");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "attendencetypes");

            migrationBuilder.DropTable(
                name: "programmes");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "programmetypes");

            migrationBuilder.DropTable(
                name: "faculties");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "campuses");

            migrationBuilder.RenameColumn(
                name: "SystemModuleId",
                table: "systemsubmodules",
                newName: "SystemmoduleId");

            migrationBuilder.RenameIndex(
                name: "IX_systemsubmodules_SystemModuleId",
                table: "systemsubmodules",
                newName: "IX_systemsubmodules_SystemmoduleId");

            migrationBuilder.RenameColumn(
                name: "SystemModuleId",
                table: "rolesystemmodules",
                newName: "SystemmoduleId");

            migrationBuilder.RenameIndex(
                name: "IX_rolesystemmodules_SystemModuleId",
                table: "rolesystemmodules",
                newName: "IX_rolesystemmodules_SystemmoduleId");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "auditEntries",
                newName: "UserName");

            migrationBuilder.AlterColumn<int>(
                name: "EntityId",
                table: "auditEntries",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "auditEntries",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "auditEntries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_rolesystemmodules_systemmodules_SystemmoduleId",
                table: "rolesystemmodules",
                column: "SystemmoduleId",
                principalTable: "systemmodules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_systemsubmodules_systemmodules_SystemmoduleId",
                table: "systemsubmodules",
                column: "SystemmoduleId",
                principalTable: "systemmodules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
