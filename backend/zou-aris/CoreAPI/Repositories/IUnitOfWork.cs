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
    public interface IUnitOfWork:IDisposable
    {
       
        IProvinceRepository provinceRepository { get; }
        IDistrictRepository districtRepository { get; }

        ICampusTypeRepository campusTypeRepository { get; }

        ICampusRepository campusRepository { get; }

        IEmailRepository emailRepository { get; }

        ITokenInfoRepository tokenInfoRepository { get; }

        IUserRepository userRepository { get; }


        IUserCampusRepository userCampusRepository { get; }

        IUserDepartmentRepository userDepartmentRepository { get; }
        IFacultyRepository facultyRepository { get; }

        IProgrammeTypeRepository programmeTypeRepository { get; }

        IAttendenceTypeRepository attendenceTypeRepository { get; }

        IProgrammeRepository programmeRepository { get; }
        ICourseRepository courseRepository { get; }

        IGlobalsettingtemplateRepository globalsettingtemplateRepository { get; }

        IGeneralregulationRepository generalregulationRepository { get; }

        IGeneralregulationacademicruleRepository generalregulationacademicruleRepository { get; }
        IGeneralregulationregistrationruleRepository generalregulationregistrationruleRepository { get; }
        IAcademicregulationRepository academicregulationRepository { get; }
        IAcademicregulationparameterRepository academicregulationparameterRepository { get; }
        IPrerequisiteRepository prerequisiteRepository { get; }
        IAlternativeRepository alternativeRepository { get; }
        IAdmissionTemplateRepository admissionTemplateRepository { get; }

        IAdmissionprogrammeRepository admissionprogrammeRepository { get; }

        IAdmissionprogrammeattendencetypeRepository admissionprogrammeattendencetypeRepository { get; }
        IApplicantTypeRepository applicantTypeRepository { get; }

        IAdmissionfeetampleRepository admissionfeetampleRepository { get; }

        IAdmissionfeeRepository admissionfeeRepository { get; }

        ICurrencyRepository currencyRepository { get; }
        IAdmissionSessionRepository admissionSessionRepository { get; }

        IDocumentRepository documentRepository { get; }

        ISubjectRepository subjectRepository { get; }

        IAdmissionDocumentRepository admissionDocumentRepository { get; }
        IAdmissionsessiontemplateRepository admissionsessiontemplateRepository { get; }

        IApplicantRepository applicantRepository { get; }

        IApplicationRepository applicationRepository { get; }

        IApplicationPaymentRepository applicationPaymentRepository { get; }

        IApplicationProgrammeRepository applicationProgrammeRepository { get; }

        IApplicantDocumentRepository applicantDocumentRepository { get; }
        IApplicantSubjectRepository applicantSubjectRepository { get; }

        IApplicantOtherqualificationRepository applicantOtherqualificationRepository { get; }

        IApplicantWorkExperienceRepository applicantWorkExperienceRepository { get; }

        IApplicantStudentRepository applicantStudentRepository { get; }

        IEntryModeRepository entryModeRepository { get; }

        IEntryModeRequirementRepository entryModeRequirementRepository { get; }


        IApplicationEntryModeDocumentRepository applicationEntryModeDocumentRepository { get; }
        IProgrammehistoryRepository programmehistoryRepository { get; }
        IProgrammeSpecializationRepository programmeSpecializationRepository { get; }

        IAdmissionattendencetypeRepository admissionattendencetypeRepository { get; }

        IDepartmentRepository departmentRepository { get; } 

        ISystempermissionRepository systempermissionRepository { get; }
        IRoleRepository roleRepository { get; }
        IRoleSystemmoduleRepository roleSystemmoduleRepository { get; }

        IRolesystempermissionRepository roleSystempermissionRepository { get; }

        IRolesystemsubmoduleRepository rolesystemsubmoduleRepository { get; }

        ISystemmoduleRepository systemModuleRepository { get; }

        ISystemsubmoduleRepository systemSubmoduleRepository { get; }

        IStudentRepository  studentRepository { get; }

        IStudentProgrammeRepository studentProgrammeRepository { get; }

        IStudentContactRepository studentContactRepository { get; }

        IStudentKinRepository studentKinRepository { get; }

        IRegistrationFeeTemplateRepository registrationFeeTemplateRepository { get; }

        IRegistrationFeeRepository registrationFeeRepository { get; }

        ISemesterRepository semesterRepository { get; }

        IRegistraationPeriodRepository registraationPeriodRepository { get; }

        IExaminationPeriodRepository examinationPeriodRepository { get; }
     
        Task<int> Save();
    }
}
