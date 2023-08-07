using CoreAPI.Services.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Administration.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        public DashboardController(DashboardService service)
        {
            _service= service;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAdminDashboard(int id)
        {
            var response = await _service.GetAdminDashboard(id);  
            return Ok(response);
        }

    }
}
