
using CoreAPI.Dto;
using CoreAPI.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Administration.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
      
        private readonly IAuthService _service;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IAuthService service, ILogger<LoginController> logger)
        {

         
            _service = service;
            _logger = logger;
        }

        [HttpPost]

        public async Task<ActionResult> Login([FromBody] AdminAuthDto dto)
        {
            var response = await _service.Login(dto);
            if (!response.status)
            {
              return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
