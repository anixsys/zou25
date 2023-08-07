namespace CoreAPI.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<Object> GetAdminDashboard(int admissionsessionId);
    }
}
