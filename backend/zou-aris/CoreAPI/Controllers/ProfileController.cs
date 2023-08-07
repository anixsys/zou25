using CoreAPI.Dto;
using CoreAPI.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IAuthService service, ILogger<ProfileController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<ProfileReponse>> GetProfile()
        {
            var response = await _service.GetProfileAsync();
            return Ok(response);
        }

      
        [HttpPost("changepassword")]
        public async Task<ActionResult<ResponseDto>> changepassword([FromBody] ChangePasswordDto dto)
        {
            var response = await _service.ChangePassword(dto);
            return Ok(response);
        }



    }
}
