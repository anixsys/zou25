using AutoMapper;
using CoreAPI.Models;
using System.Security;

namespace CoreAPI.Dto
{
    public class GenericMapper:Profile
    {
        public GenericMapper()
        {
            CreateMap<CampusDto, Campus>().ReverseMap();
            CreateMap<ProvinceDto, Province>().ReverseMap();
            CreateMap<DistrictDto, District>().ReverseMap();
            CreateMap<CampusTypeDto, CampusType>().ReverseMap();
            CreateMap<RoleSystemmoduleRequestDto, RoleSystemmodule>().ReverseMap();
            CreateMap<RoleSubmoduleRequestDto, RoleSystemsubmodule>().ReverseMap();
            CreateMap<RoleRequestDto, Role>().ReverseMap();
            CreateMap<RolePermissionRequestDto, RoleSystempermission>().ReverseMap();
            CreateMap<SystemModuleRequestDto, Systemmodule>().ReverseMap();
            CreateMap<SystemsubmoduleRequestDto, Systemsubmodule>().ReverseMap();
            CreateMap<PermissionRequestDto, Systempermission>().ReverseMap();
            CreateMap<UserResponseDto, User>().ReverseMap();
            CreateMap<DepartmentDto, Department>().ReverseMap();
            CreateMap<FacultyRequestDto, Faculty>().ReverseMap();
            CreateMap<ProgrammeTypeDto, ProgrammeType>().ReverseMap();
            CreateMap<ProgrammeRequestDto, Programme>().ReverseMap();
            CreateMap<AttendenceTypeRequestDto, AttendenceType>().ReverseMap();
            CreateMap<CourseRequestDto, Course>().ReverseMap();
            CreateMap<GlobalsettingRequestDto, Globalsettingtemplate>().ReverseMap();
            CreateMap<GeneralregulationRequestDto, Generalregulation>().ReverseMap();
            CreateMap<GeneralregulationacademicruleRequestDto, Generalregulationacademicrule>().ReverseMap();
            CreateMap<GeneralrgulationregistrationRequestDto, Generalregulationregistrationrule>().ReverseMap();
            CreateMap<AcademicregulationRequestDto, Academicregulation>().ReverseMap();
            CreateMap<AcademicregulationparameterDto, Academicregulationparameter>().ReverseMap();
            CreateMap<PrerequisiteDto, Prerequisite>().ReverseMap();
            CreateMap<AlternativeDto, Alternative>().ReverseMap();
            CreateMap<AdmissionTemplateRequestDto, Admissiontemplate>().ReverseMap();
            CreateMap<AdmissionprogrammeRequestDto, Admissionprogramme>().ReverseMap();
            CreateMap<AdmissionattendencetypeRequestDto, Admissionattendencetype>().ReverseMap();
            CreateMap<ApplicantTypeDto, Applicanttype>().ReverseMap();
            CreateMap<AdmissionfeetemplateDto, AdmissionFeeTemplate>().ReverseMap();
            CreateMap<AdmissionFeeDto, AdmissionFee>().ReverseMap();
            CreateMap<CurrencyDto, Currency>().ReverseMap();
            CreateMap<AdmissionSessionDto, AdmissionSession>().ReverseMap();
            CreateMap<DocumentDto, Document>().ReverseMap();
            CreateMap<SubjectDto, Subject>().ReverseMap();
            CreateMap<AdmissionDocumentDto, AdmissionDocument>().ReverseMap();
            CreateMap<ApplicantDto, Applicant>().ReverseMap();
            CreateMap<ApplicationProgrammeDto, ApplicationProgramme>().ReverseMap();
            CreateMap<ApplicantSubjectDto, ApplicantSubject>().ReverseMap();
            CreateMap<ApplicantOtherqualificationDto, ApplicantOtherqualification>().ReverseMap();
            CreateMap<ApplicantWorkExperienceDto, ApplicantWorkexperience>().ReverseMap();
            CreateMap<ProgrammeSpecialization, ProgrammeSpecializationDto>().ReverseMap();
            CreateMap<ProgrammeHistory, ProgrammeHistoryDto>().ReverseMap();
        }
    }
}
