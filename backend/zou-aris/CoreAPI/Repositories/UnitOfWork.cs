using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Academicregulationparameters;
using CoreAPI.Repositories.Academicregulations;
using CoreAPI.Repositories.Admissionattendencetypes;
using CoreAPI.Repositories.AdmissionDocuments;
using CoreAPI.Repositories.AdmissionFees;
using CoreAPI.Repositories.Admissionfeetemplates;
using CoreAPI.Repositories.Admissionprogrammeattendencetypes;
using CoreAPI.Repositories.Admissionprogrammes;
using CoreAPI.Repositories.Admissionsessions;
using CoreAPI.Repositories.Admissionsesssiontemplates;
using CoreAPI.Repositories.Admissiontemplates;
using CoreAPI.Repositories.Alternatives;
using CoreAPI.Repositories.Applicantdocuments;
using CoreAPI.Repositories.Applicantotherqualifications;
using CoreAPI.Repositories.Applicants;
using CoreAPI.Repositories.Applicantstudents;
using CoreAPI.Repositories.Applicantsubjects;
using CoreAPI.Repositories.Applicanttypes;
using CoreAPI.Repositories.Applicantworkexperiences;
using CoreAPI.Repositories.Applicationentrymodes;
using CoreAPI.Repositories.Applicationpayments;
using CoreAPI.Repositories.Applicationprogrammes;
using CoreAPI.Repositories.Applications;
using CoreAPI.Repositories.Attendencetypes;
using CoreAPI.Repositories.Campuses;
using CoreAPI.Repositories.Campustypes;
using CoreAPI.Repositories.Courses;
using CoreAPI.Repositories.Currencies;
using CoreAPI.Repositories.Departments;
using CoreAPI.Repositories.Districts;
using CoreAPI.Repositories.Documents;
using CoreAPI.Repositories.Emails;
using CoreAPI.Repositories.Entrymoderequirements;
using CoreAPI.Repositories.Entrymodes;
using CoreAPI.Repositories.ExaminationPeriods;
using CoreAPI.Repositories.Faculties;
using CoreAPI.Repositories.Generalregulationacademicrules;
using CoreAPI.Repositories.Generalregulationregistrationrules;
using CoreAPI.Repositories.Generalregulations;
using CoreAPI.Repositories.Globalsettingtemplates;
using CoreAPI.Repositories.Prerequisites;
using CoreAPI.Repositories.Programmehistories;
using CoreAPI.Repositories.Programmes;
using CoreAPI.Repositories.Programmespecializations;
using CoreAPI.Repositories.ProgrammeTypes;
using CoreAPI.Repositories.Provinces;
using CoreAPI.Repositories.RegistrationFees;
using CoreAPI.Repositories.RegistrationFeeTemplates;
using CoreAPI.Repositories.RegistrationPeriods;
using CoreAPI.Repositories.Roles;
using CoreAPI.Repositories.RoleSystemmodules;
using CoreAPI.Repositories.Rolesystempermissions;
using CoreAPI.Repositories.Rolesystemsubmodules;
using CoreAPI.Repositories.Semesters;
using CoreAPI.Repositories.StudentContacts;
using CoreAPI.Repositories.StudentKins;
using CoreAPI.Repositories.StudentProgrammes;
using CoreAPI.Repositories.Students;
using CoreAPI.Repositories.Subjects;
using CoreAPI.Repositories.Systemmodules;
using CoreAPI.Repositories.Systempermissions;
using CoreAPI.Repositories.Systemsubmodules;
using CoreAPI.Repositories.Tokeninfos;
using CoreAPI.Repositories.UserCampuses;
using CoreAPI.Repositories.UserDepartments;
using CoreAPI.Repositories.Users;

namespace CoreAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly CoreDbContext _context;
        public UnitOfWork(CoreDbContext context) 
        {
             _context = context;
            provinceRepository = new ProvinceRepository(_context);
            districtRepository = new DistrictRepository(_context);
            campusTypeRepository = new CamputTypeRepository(_context);
            campusRepository    = new CampusRepository(_context);
            emailRepository = new EmailRepository(_context);
            tokenInfoRepository = new TokenInfoRepository(_context);
            userRepository = new UserRepository(_context);
            districtRepository = new DistrictRepository(_context);
            campusRepository = new CampusRepository(_context);
            userCampusRepository = new UserCampusRepository(_context);
            facultyRepository = new FacultyRepository(_context);
            programmeTypeRepository = new ProgrammeTypeRepository(_context);
            attendenceTypeRepository = new AttendenceTypeRepository(_context);
            programmeRepository = new ProgrammeRepository(_context);
            courseRepository = new CourseRepository(_context);
            globalsettingtemplateRepository = new GlobalsettingtemplateRepository(_context);
            generalregulationRepository = new GeneralregulationRepository(_context);
            generalregulationacademicruleRepository = new GeneralregulationacademicruleRepository(_context);
            generalregulationregistrationruleRepository = new GeneralregulationregistrationruleRepository(_context);
            academicregulationRepository = new AcademicregulationRepository(_context);
            academicregulationparameterRepository = new AcademicregulationparameterRepository(_context);
            prerequisiteRepository = new PrerequisiteRepository(_context);
            alternativeRepository = new AlternativeRepository(_context);
            admissionTemplateRepository = new AdmissionTemplateRepository(_context);
            admissionprogrammeRepository = new AdmissionprogrammeRepository(_context);
            admissionprogrammeattendencetypeRepository = new AdmissionprogrammeattendenceRepository(_context);
            applicantTypeRepository = new ApplicabtTypeRepository(_context);
            admissionfeetampleRepository = new AdmissionfeetemplateRepository(_context);
            admissionfeeRepository = new AdmissionfeeRepository(_context);
            currencyRepository = new CurrencyRepository(_context);
            admissionSessionRepository = new AdmissionSessionRepository(_context);
            documentRepository = new DocumentRepository(_context);
            subjectRepository = new SubjectRepository(_context);
            admissionDocumentRepository = new AdmissionDocumentRepository(_context);
            admissionsessiontemplateRepository = new AdmissionsessiontemplateRepository(_context);
            userDepartmentRepository = new UserDepartmentRepository(_context);
            applicantRepository = new ApplicantRepository(_context);
            applicationRepository = new ApplicationRepository(_context);
            applicationPaymentRepository = new ApplicationPaymentRepository(_context);
            applicationProgrammeRepository = new ApplicationProgrammeRepository(_context);
            applicantDocumentRepository = new ApplicantDocumentRepository(_context);
            applicantOtherqualificationRepository = new ApplicantOtherqualificationRepository(_context);
            applicantSubjectRepository = new ApplicantSubjectRepository(_context);
            applicantWorkExperienceRepository = new ApplicantWorkExperienceRepository(_context);
            applicantStudentRepository = new ApplicantStudentRepository(_context);
            entryModeRepository = new EntryModeRepository(_context);
            entryModeRequirementRepository = new EntryModeRequirementRepository(_context);
            applicationEntryModeDocumentRepository = new ApplicationEntryModeDocumentRepository(_context);
            programmehistoryRepository = new ProgrammehistoryRepository(_context);
            programmeSpecializationRepository = new ProgrammespecializationRepository(_context);
            roleRepository = new RoleRepository(_context);
            roleSystemsubmoduleRepository = new RolesystemsubmoduleRepository(_context);
            systemModuleRepository = new SystemmoduleRepository(_context);
            systempermissionRepository = new SystempermissionRepository(_context);
            systemSubmoduleRepository = new SystemsubmoduleRepository(_context);
            admissionattendencetypeRepository = new AdmissionattendencetypeRepository(_context);
            departmentRepository = new DepartmentRepository(_context);
            roleSystemmoduleRepository = new RoleSystemmoduleRepository(_context);
            rolesystemsubmoduleRepository = new RolesystemsubmoduleRepository(_context);
            roleSystempermissionRepository = new RolesystempermissionRepository(_context);
            studentRepository = new StudentRepository(_context);
            studentProgrammeRepository = new StudentProgrammeRepository(_context);  
            studentKinRepository = new StudentKinRepository(_context);
            studentContactRepository = new StudentContactRepository(_context);
            registrationFeeTemplateRepository = new RegistrationFeeTemplateRepository(_context);
            registrationFeeRepository = new RegistrationFeeRepository(_context);
            semesterRepository = new SemesterRepository(_context); 
            registraationPeriodRepository = new RegistrationPeriodRepository(_context);
            examinationPeriodRepository = new ExaminationPeriodRepository(_context);    
        }


        public IDepartmentRepository departmentRepository { get; private set; }

        public IEmailRepository emailRepository { get; private set; }

        public ITokenInfoRepository tokenInfoRepository { get; private set; }


        public IProvinceRepository provinceRepository { get; private set; }

        public IDistrictRepository districtRepository { get; private set; }

        public ICampusRepository campusRepository { get; private set; }

        public ICampusTypeRepository campusTypeRepository { get; private set; }

        public IUserCampusRepository userCampusRepository { get; private set; }

        public IFacultyRepository facultyRepository { get; private set; }

        public IProgrammeTypeRepository programmeTypeRepository { get; private set; }
        public IAttendenceTypeRepository attendenceTypeRepository { get; private set; }

        public IProgrammeRepository programmeRepository { get; private set; }
        public ICourseRepository courseRepository { get; private set; }

        public IGlobalsettingtemplateRepository globalsettingtemplateRepository { get; private set; }

        public IGeneralregulationRepository generalregulationRepository { get; private set; }

        public IGeneralregulationacademicruleRepository generalregulationacademicruleRepository { get; private set; }

        public IGeneralregulationregistrationruleRepository generalregulationregistrationruleRepository { get; private set; }

        public IAcademicregulationRepository academicregulationRepository { get; private set; }

        public IAcademicregulationparameterRepository academicregulationparameterRepository { get; private set; }

        public IPrerequisiteRepository prerequisiteRepository { get; private set; }
        public IAlternativeRepository alternativeRepository { get; private set; }

        public IAdmissionTemplateRepository admissionTemplateRepository { get; private set; }
        public IAdmissionprogrammeRepository admissionprogrammeRepository { get; private set; }

        public IAdmissionprogrammeattendencetypeRepository admissionprogrammeattendencetypeRepository { get; private set; }

        public IApplicantTypeRepository applicantTypeRepository { get; private set; }

        public IAdmissionfeetampleRepository admissionfeetampleRepository { get; private set; }

        public IAdmissionfeeRepository admissionfeeRepository { get; private set; }
        public ICurrencyRepository currencyRepository { get; private set; }

        public IAdmissionSessionRepository admissionSessionRepository { get; private set; }

        public IDocumentRepository documentRepository { get; private set; }

        public ISubjectRepository subjectRepository { get; private set; }

        public IAdmissionDocumentRepository admissionDocumentRepository { get; private set; }

        public IAdmissionsessiontemplateRepository admissionsessiontemplateRepository { get; private set; }

        public IUserDepartmentRepository userDepartmentRepository { get; private set; }

        public IApplicantRepository applicantRepository { get; private set; }

        public IApplicationRepository applicationRepository { get; private set; }

        public IApplicationPaymentRepository applicationPaymentRepository { get; private set; }

        public IApplicationProgrammeRepository applicationProgrammeRepository { get; private set; }

        public IApplicantDocumentRepository applicantDocumentRepository { get; private set; }

        public IApplicantSubjectRepository applicantSubjectRepository { get; private set; }

        public IApplicantOtherqualificationRepository applicantOtherqualificationRepository { get; private set; }

        public IApplicantWorkExperienceRepository applicantWorkExperienceRepository { get; private set; }

        public IApplicantStudentRepository applicantStudentRepository { get; private set; }

        public IEntryModeRepository entryModeRepository { get; private set; }

        public IEntryModeRequirementRepository entryModeRequirementRepository { get; private set; }


        public IApplicationEntryModeDocumentRepository applicationEntryModeDocumentRepository { get; private set; }

        public IProgrammehistoryRepository programmehistoryRepository { get; private set; }

        public IProgrammeSpecializationRepository programmeSpecializationRepository { get; private set; }

        public IUserRepository userRepository { get; private set; }
        public IRoleRepository roleRepository { get; private set; }

        public ISystemmoduleRepository systemModuleRepository { get; private set; }

        public ISystemsubmoduleRepository systemSubmoduleRepository { get; private set; }

        public ISystempermissionRepository systempermissionRepository { get; private set; }

        public IRoleSystemmoduleRepository roleSystemmoduleRepository { get; private set; }

        public IRolesystemsubmoduleRepository roleSystemsubmoduleRepository { get; private set; }

        public IRolesystemsubmoduleRepository rolesystemsubmoduleRepository { get; private set; }


        public IRolesystempermissionRepository roleSystempermissionRepository { get; private set; }

        public IAdmissionattendencetypeRepository admissionattendencetypeRepository { get; private set; }

        public IStudentRepository studentRepository { get; private set; }

        public IStudentProgrammeRepository studentProgrammeRepository { get; private set; }

        public IStudentContactRepository studentContactRepository { get; private set; }

        public IStudentKinRepository studentKinRepository { get; private set; }

        public IRegistrationFeeTemplateRepository registrationFeeTemplateRepository { get; private set; }

        public IRegistrationFeeRepository registrationFeeRepository { get; private set; }

        public ISemesterRepository semesterRepository { get; private set; }

        public IRegistraationPeriodRepository registraationPeriodRepository { get; private set; }

        public IExaminationPeriodRepository examinationPeriodRepository { get; private set; }

        public void Dispose()
        {
           _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
