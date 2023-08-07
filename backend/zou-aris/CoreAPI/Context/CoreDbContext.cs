using CoreAPI.Interface;
using CoreAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CoreAPI.Data
{
    public class CoreDbContext:IdentityDbContext<User,Role,string>
    {
        private readonly string _username;
        public CoreDbContext(DbContextOptions<CoreDbContext> options, IHttpContextAccessor httpContextAccessor) :base(options) {
            if (httpContextAccessor.HttpContext != null)
            {
                var claimsPrincipal = httpContextAccessor.HttpContext.User;
                _username = "Unauthenticated User";
                if (claimsPrincipal != null && claimsPrincipal.Identity.IsAuthenticated)
                {
                    _username = claimsPrincipal.Identity.Name;
                }
            }
            else
            {
                _username = "Unauthenticated User";
            }
        }

        public DbSet<User> users { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<AuditEntry> auditEntries { get; set; }

        public DbSet<Province> provinces { get; set; }   

        public DbSet<District> districts { get; set; }

        public DbSet<CampusType> campusTypes { get; set; }

        public DbSet<Campus> campuses { get; set; } 
        public DbSet<Systemmodule> systemmodules { get; set; }
        public DbSet<Systemsubmodule> systemsubmodules { get; set; }

        public DbSet<Systempermission> systempermissions { get; set; }
        public DbSet<Academicregulation> academicregulations { get; set; }
        public DbSet<Academicregulationparameter> academicregulationparameters { get; set; }

        public DbSet<Admissionattendencetype> admissionattendencetypes { get; set; }

        public DbSet<AdmissionDocument> admissiondocuments { get; set; }

        public DbSet<AdmissionFee> admissionfees { get; set; }

        public DbSet<AdmissionFeeTemplate> admissionfeetemplates { get; set; }

        public DbSet<Admissionprogramme> admissionprogrammes { get; set; }

        public DbSet<AdmissionSession> admissionsessions { get; set; }

        public DbSet<Admissionsessiontemplate> admissionsessiontemplates { get; set; }

        public DbSet<Admissiontemplate> admissiontemplates { get; set; }

        public DbSet<Alternative> alternatives { get; set; }

        public DbSet<Applicant> applicants { get; set; }

        public DbSet<ApplicantDocument> applicantdocuments { get; set; }

        public DbSet<ApplicantOtherqualification> applicantotherqualifications { get; set; }

        public DbSet<ApplicantStudentnumber> applicantstudentnumbers { get; set; }

        public DbSet<ApplicantSubject> applicantsubjects { get; set; }

        public DbSet<Applicanttype> applicanttypes { get; set; }

        public DbSet<ApplicantWorkexperience> applicantworkexperiences { get; set; }

        public DbSet<Application> applications { get; set; }

        public DbSet<ApplicationEntryModeDocument> applicationentrymodedocuments { get; set; }

        public DbSet<ApplicationPayment> applicationpayments { get; set; }

        public DbSet<ApplicationProgramme> applicationprogrammes { get; set; }

        public DbSet<AttendenceType> attendencetypes { get; set; }
        public DbSet<Course> courses { get; set; }

        public DbSet<Currency> currency { get; set; }

        public DbSet<Department> departments { get; set; }
        public DbSet<EmailQueue> emailqueues { get; set; }

        public DbSet<EntryMode> entrymodes { get; set; }

        public DbSet<EntryModeRequirement> entrymoderequirements { get; set; }

        public DbSet<Faculty> faculties { get; set; }

        public DbSet<Generalregulation> generalregulations { get; set; }

        public DbSet<Generalregulationacademicrule> generalregulationacademicrules { get; set; }
        public DbSet<Generalregulationregistrationrule> generalregulationregistrationrules { get; set; }

        public DbSet<Globalsettingtemplate> globalsettingtemplate { get; set; }

        public DbSet<Prerequisite> prerequisites { get; set; }

        public DbSet<Programme> programmes { get; set; }

        public DbSet<ProgrammeHistory> programmehistory { get; set; }
        public DbSet<ProgrammeSpecialization> programmespecializations { get; set; }
        public DbSet<ProgrammeType> programmetypes { get; set; }

        public DbSet<Subject> subjects { get; set; }

        public DbSet<TokenInfo> tokeninfo { get; set; } 
        public DbSet<UserCampus> usercampuses { get; set; }

        public DbSet<UserDepartment> userdepartments { get; set; }
        public DbSet<RoleSystempermission> rolesystempermissions { get; set; }  
        public DbSet<RoleSystemmodule> rolesystemmodules { get; set; }
        public DbSet<RoleSystemsubmodule> rolesystemsubmodules { get; set; }
        public DbSet<Student> students { get; set; }

        public DbSet<StudentProgramme> studentProgrammes { get; set; }

        public DbSet<StudentKin> studentKins { get; set; }  

        public DbSet<StudentContact> studentContacts { get; set; }

        public DbSet<RegistrationFeeTemplate> registrationFeeTemplates { get; set; }

        public DbSet<RegistrationFee> registrationFees { get; set; }

        public DbSet<Semester> semesters { get; set; }

        public DbSet<RegistrationPeriod> registrationPeriods { get; set; }  

        public DbSet<ExaminationPeriod> examinationPeriods { get; set; }

        public DbSet<CourseOnOfferTemplate> courseOnOfferTemplates { get; set; }

        public DbSet<CourseOnOffer> courseOnOffers { get; set; }

        public DbSet<SemesterCourse> semesterCourses { get; set; }

        public DbSet<SemesterRegistrationFeeTemplate> semesterRegistrationFeeTemplates { get; set; }    

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().Property(q => q.Status).HasDefaultValue("ACTIVE");
            builder.Entity<ApplicantStudentnumber>().Property(q => q.DocVerified).HasDefaultValue("N");
            builder.Entity<ApplicantDocument>().Property(q => q.Verified).HasDefaultValue("PENDING");
            builder.Entity<StudentProgramme>().Property(q=>q.Status).HasDefaultValue("PENDING");
            builder.Entity<RegistrationFeeTemplate>().Property(q => q.Status).HasDefaultValue("PENDING");
            builder.Entity<Semester>().Property(q => q.Status).HasDefaultValue("PENDING");
            builder.Entity<RegistrationPeriod>().Property(q => q.Status).HasDefaultValue("PENDING");
            builder.Entity<ExaminationPeriod>().Property(q => q.Status).HasDefaultValue("PENDING");
            builder.Entity<CourseOnOfferTemplate>().Property(q => q.Status).HasDefaultValue("PENDING");
            builder.Entity<Student>().Property(q=>q.FullName).HasComputedColumnSql(@"""Name"" || ' ' || ""Surname""", stored:true);
            builder.Entity<Applicant>().Property(q => q.FullName).HasComputedColumnSql(@"""Name"" || ' ' || ""Surname""", stored:true);
            builder.Entity<AuditEntry>().Property(a => a.Changes).HasConversion(value => JsonConvert.SerializeObject(value),
                                                                               serializedValue=>JsonConvert.DeserializeObject<Dictionary<string,object>>(serializedValue)) ;

            //seeders roles

            builder.Entity<Role>().HasData(new Role { Id = "49aa7b86-508c-4666-8bd8-0631e84e2082", View = "ADMIN", Name = "Administrator", NormalizedName = "ADMINISTRATOR", ConcurrencyStamp = DateTime.Now.ToString() });

            // seeding default user 
            User user = new User { Id = "fe0773fe-8685-420c-837f-c6222de3ba2e", Email = "admin@anixsys.co.zw", EmailConfirmed = true, Name = "Admin", Surname = "Admin", Status = "ACTIVE",Gender="F",Title="Mr", UserName = "admin@anixsys.co.zw", NormalizedUserName = "ADMIN@ANIXSYS.CO.ZW", NormalizedEmail = "ADMIN@ANIXSYS.CO.ZW", PhoneNumber = "000000000" };
            PasswordHasher<User> ph = new PasswordHasher<User>();
            user.PasswordHash = ph.HashPassword(user, "Administrator@2023");
            builder.Entity<User>().HasData(user);

            // seeding role to user 

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082",
                UserId = "fe0773fe-8685-420c-837f-c6222de3ba2e",
            });


            /// seeding system modules
            /// 
            builder.Entity<Systemmodule>().HasData(
                 new Systemmodule { Id = 1, Name = "System Configuration", Icon = "mdi-cogs" }
                 );
            builder.Entity<Systemsubmodule>().HasData(new Systemsubmodule
            {
                Id = 1,
                SystemModuleId = 1,
                Name = "System Modules",
                Icon = "mdi-cogs",
                Url = "/systemmodules"
            },
            new Systemsubmodule
            {
                Id = 2,
                SystemModuleId = 1,
                Name = "System Roles",
                Icon = "mdi-cogs",
                Url = "/roles"
            },
             new Systemsubmodule
             {
                 Id = 3,
                 SystemModuleId = 1,
                 Name = "System Users",
                 Icon = "mdi-cogs",
                 Url = "/users"
             });
            builder.Entity<Systempermission>().HasData(new Systempermission
            {
                Id = 1,
                SystemSubmoduleId = 1,
                Name = "SM.CREATE"
            },
            new Systempermission
            {
                Id = 2,
                SystemSubmoduleId = 1,
                Name = "SM.UPDATE"
            },
            new Systempermission
            {
                Id = 3,
                SystemSubmoduleId = 1,
                Name = "SM.DELETE"
            },
             new Systempermission
             {
                 Id = 4,
                 SystemSubmoduleId = 2,
                 Name = "SSM.CREATE"
             },
            new Systempermission
            {
                Id = 5,
                SystemSubmoduleId = 2,
                Name = "SSM.UPDATE"
            },
            new Systempermission
            {
                Id = 6,
                SystemSubmoduleId = 2,
                Name = "SSM.DELETE"
            },
             new Systempermission
             {
                 Id = 7,
                 SystemSubmoduleId = 2,
                 Name = "RSM.ASSIGN"
             },
             new Systempermission
             {
                 Id = 8,
                 SystemSubmoduleId = 3,
                 Name = "USERS.VIEW"
             },
            new Systempermission
            {
                Id = 9,
                SystemSubmoduleId = 3,
                Name = "USERS.CREATE"
            },
            new Systempermission
            {
                Id = 10,
                SystemSubmoduleId = 3,
                Name = "USER.VIEW"
            },
            new Systempermission
            {
                Id = 11,
                SystemSubmoduleId = 3,
                Name = "PASSWORD.RESET"
            },
            new Systempermission
            {
                Id = 12,
                SystemSubmoduleId = 3,
                Name = "USER.UPDATE"
            });

            builder.Entity<RoleSystemmodule>().HasData(new RoleSystemmodule { Id = 1, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", SystemModuleId = 1 });
            builder.Entity<RoleSystemsubmodule>().HasData(
                                  new RoleSystemsubmodule { Id = 1, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemmoduleId = 1, SystemSubmoduleId = 1 },
                                  new RoleSystemsubmodule { Id = 2, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemmoduleId = 1, SystemSubmoduleId = 2 },
                                  new RoleSystemsubmodule { Id = 3, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemmoduleId = 1, SystemSubmoduleId = 3 }
                                  );
            builder.Entity<RoleSystempermission>().HasData(
                new RoleSystempermission { Id = 1, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemsubmoduleId = 1, SystempermissionId = 1 },
                new RoleSystempermission { Id = 2, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemsubmoduleId = 1, SystempermissionId = 2 },
                new RoleSystempermission { Id = 3, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemsubmoduleId = 1, SystempermissionId = 3 },
                new RoleSystempermission { Id = 4, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemsubmoduleId = 2, SystempermissionId = 4 },
                new RoleSystempermission { Id = 5, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemsubmoduleId = 2, SystempermissionId = 5 },
                new RoleSystempermission { Id = 6, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemsubmoduleId = 2, SystempermissionId = 6 },
                new RoleSystempermission { Id = 7, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemsubmoduleId = 3, SystempermissionId = 7 },
                new RoleSystempermission { Id = 8, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemsubmoduleId = 3, SystempermissionId = 8 },
                new RoleSystempermission { Id = 9, RoleId = "49aa7b86-508c-4666-8bd8-0631e84e2082", RoleSystemsubmoduleId = 3, SystempermissionId = 9 }

            );

        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var auditEntries = BeforeSaveChanges();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await OnAfterSaveChangesAsync(auditEntries);
            return result;
        }

        private List<AuditEntry> BeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var entries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                // Dot not audit entities that are not tracked, not changed, or not of type IAuditable
                if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged || !(entry.Entity is IAuditable))
                    continue;

                if (entry.Entity is Auditable)
                {
                    var auditableEntity = entry.Entity as Auditable;
                    if (entry.State == EntityState.Added)
                    {

                        if (auditableEntity != null)
                        {
                            auditableEntity.DateCreated = DateTimeOffset.UtcNow;
                        }
                    }
                    if (entry.State == EntityState.Modified)
                    {

                        if (auditableEntity != null)
                        {
                            auditableEntity.DateUpdated = DateTimeOffset.UtcNow;
                        }
                    }
                }
                var auditEntry = new AuditEntry
                {
                    ActionType = entry.State == EntityState.Added ? "INSERT" : entry.State == EntityState.Deleted ? "DELETE" : "UPDATE",
                    EntityId = entry.Properties.Single(p => p.Metadata.IsPrimaryKey()).CurrentValue.ToString(),
                    EntityName = entry.Metadata.ClrType.Name,
                    Username = _username,
                    TimeStamp = DateTime.UtcNow,
                    Changes = entry.Properties.Select(p => new { p.Metadata.Name, p.CurrentValue }).ToDictionary(i => i.Name, i => i.CurrentValue),

                    // TempProperties are properties that are only generated on save, e.g. ID's
                    // These properties will be set correctly after the audited entity has been saved
                    TempProperties = entry.Properties.Where(p => p.IsTemporary).ToList(),
                };

                entries.Add(auditEntry);
            }
            return entries;
        }


        private Task OnAfterSaveChangesAsync(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            // For each temporary property in each audit entry - update the value in the audit entry to the actual (generated) value
            foreach (var entry in auditEntries)
            {
                foreach (var prop in entry.TempProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        entry.EntityId = prop.CurrentValue.ToString();
                        entry.Changes[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        entry.Changes[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }
            }

            auditEntries.AddRange(auditEntries);
            return SaveChangesAsync();
        }

    }
}
