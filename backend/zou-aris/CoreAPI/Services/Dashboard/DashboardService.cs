using CoreAPI.Dto;
using CoreAPI.Repositories;

namespace CoreAPI.Services.Dashboard
{
    public class DashboardService:IDashboardService
    {

        private readonly IUnitOfWork _unitofwork;
        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }

        public async Task<Object> GetAdminDashboard(int admissionsessionId)
        {
            List<SummaryDto> programmetypesummary = new List<SummaryDto>();
            List<SummaryDto> campussummary = new List<SummaryDto>();
            List<SummaryDto> statussummary = new List<SummaryDto>();
            List<SummaryDto> gendersummary = new List<SummaryDto>();
            List<SummaryDto> countrysummary = new List<SummaryDto>();
            var admissionsession = _unitofwork.admissionSessionRepository.GetOne(q => q.Id == admissionsessionId);
            if (admissionsession != null)
            {
                var applications = _unitofwork.applicationRepository.Find(q => q.AdmissionSessionId == admissionsession.Id, new List<string>() { "Campus", "programmeType", "applicant" });

                var groupbygender = applications.GroupBy(q => q.applicant.Gender);
                var groupbycountry = applications.GroupBy(q => q.applicant.Country);
                var groupbystatus = applications.GroupBy(q => q.ApprovalStatus);
                var groupbycampus = applications.GroupBy(q => q.CampusId);
                var groupbyprogrammetype = applications.GroupBy(q => q.ProgrammeTypeId);



                if (groupbystatus.Count() > 0)
                {
                    var awaitingtotal = 0;
                    var approvaltotal = 0;
                    var pendingtotal = 0;
                    var rejectedtotal = 0;

                    foreach (var item in groupbystatus)
                    {



                        if (item.First().ApprovalStatus.ToUpper() == "AWAITING")
                        {

                            awaitingtotal = item.Count() > 0 ? item.Count() : 0;
                        }
                        if (item.First().ApprovalStatus.ToUpper() == "PENDING")
                        {

                            pendingtotal = item.Count() > 0 ? item.Count() : 0;
                        }
                        if (item.First().ApprovalStatus.ToUpper() == "ACCEPTED")
                        {

                            approvaltotal = item.Count() > 0 ? item.Count() : 0;
                        }
                        if (item.First().ApprovalStatus.ToUpper() == "REJECTED")
                        {

                            rejectedtotal = item.Count() > 0 ? item.Count() : 0;
                        }


                    }
                    statussummary.Add(new SummaryDto { Name = "Awaiting", Total = awaitingtotal });
                    statussummary.Add(new SummaryDto { Name = "Pending", Total = pendingtotal });
                    statussummary.Add(new SummaryDto { Name = "Accepted", Total = approvaltotal });
                    statussummary.Add(new SummaryDto { Name = "Rejected", Total = rejectedtotal });

                }

                if (groupbycampus.Count() > 0)
                {
                    foreach (var item in groupbycampus)
                    {

                        var name = item.First().Campus.Name;
                        var total = item.Count() > 0 ? item.Count() : 0;

                        campussummary.Add(new SummaryDto { Name = name, Total = total });
                    }
                }

                if (groupbygender.Count() > 0)
                {
                    foreach (var item in groupbygender)
                    {

                        var name = item.First().applicant.Gender;
                        var total = item.Count() > 0 ? item.Count() : 0;

                        gendersummary.Add(new SummaryDto { Name = name, Total = total });
                    }
                }

                if (groupbycountry.Count() > 0)
                {
                    foreach (var item in groupbycountry)
                    {

                        var name = item.First().applicant.Country;
                        var total = item.Count() > 0 ? item.Count() : 0;

                        countrysummary.Add(new SummaryDto { Name = name, Total = total });
                    }
                }
                if (groupbyprogrammetype.Count() > 0)
                {
                    foreach (var item in groupbyprogrammetype)
                    {
                        var name = item.First().programmeType.Name;
                        var total = item.Count();
                        programmetypesummary.Add(new SummaryDto { Name = name, Total = total });
                    }
                }
            }

            return new { gendersummary, campussummary, programmetypesummary, statussummary, countrysummary };
        }
    }
}
