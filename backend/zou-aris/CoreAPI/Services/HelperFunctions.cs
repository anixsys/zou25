using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CoreAPI.Services
{
    public class HelperFunctions
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContext;
        public static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly IConfiguration _configuration;
        public HelperFunctions(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpContext = httpContext;
            _configuration = configuration;
        }

        public async Task<bool> CheckCampusAccess(int campusId)
        {
            var administratorId = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.PrimarySid);
            var allowed = false;
            if (administratorId != null)
            {
                var campuspermission = _unitOfWork.userCampusRepository.Find(q => q.UserId == administratorId && q.CampusId == campusId).ToList();
                if (campuspermission.Count > 0)
                {
                    allowed = true;
                }
            }
            return allowed;
        }
        public string GetLoggedAdministratorId()
        {
            var administratorId = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.PrimarySid);
            return administratorId;
        }
        public string GenerateStudentNumber()
        {
            var year = DateTime.Now.ToString("yy");
            Random radom = new Random();
            var radomnumber = radom.Next(99999).ToString();
            var randonletter = GetRandomAlphabet();
            var studentnumber = $"P{year}{radomnumber}{randonletter}";
            return studentnumber;
        }

        public static char GetRandomAlphabet()
        {
            Random rand = new Random();
            int index = rand.Next(0, chars.Length);
            return chars[index];
        }

        public async Task<string> GeneratePassword()
        {
            int length = 7;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            var randomstring = str_build.ToString();
            var year = DateTime.Now.Year;
            var password = $"temp-{randomstring}-{year}";
            return await Task.FromResult(password);
        }

        public async Task<List<string>> GetPermissions(string name)
        {
            var role = _unitOfWork.roleRepository.GetOne(q => q.Name == name, new List<string> { "systempermissions.permission" });
            List<string> permissions = new List<string>();
            foreach (var permission in role.systempermissions) {
                permissions.Add(permission.permission.Name);
            }
            return permissions;

        }

        public async Task<string> GenerateOfferLetter(Application application, string imageurl,string? signatureurl)
        {

            var admissionprogramme = application.applicationprogrammes.Where(q => q.Status == "ACCEPTED").FirstOrDefault();
            var programme = admissionprogramme.programme.Description.ToUpper();
            var mode = application.attendenceType.Name;
            var campus = application.Campus.Name;
            var logourl = _configuration.GetSection("LOGO_URL").Value;
            string htmlContent = "<div style='width:100%'>";
            htmlContent += " <div style='text-align: center; font-weight: bolder;font-size: 22px;'>ACCEPTANCE LETTER</div>";
            htmlContent += " <hr  style='border: 2px solid black;'/>";
            htmlContent += "<table style=' width: 100%;'>";
            htmlContent += "<tbody>";
            htmlContent += $"<tr><td><img style=' width: 80px;' src='{imageurl}'/></td>";
            htmlContent += "<td style='text-align:center;'>";
            htmlContent += "<div style='font-size:22px'>Zimbabwe Open University</div>";
            htmlContent += "<div style='font-size:12px'>Telephone:+263 242 793 002/7/8</div>";
            htmlContent += "<div style='font-size:12px'>Email:admissions@zou.ac.zw</div>";
            htmlContent += "</td>";
            htmlContent += "<td style='text-align:right'>2nd Floor Corner House<br/>Cnr. Samora Machel Avenue<br/>Leopold Takawira Street<br/>Harare</td>";
            htmlContent += "</tbody>";
            htmlContent += "</table>";
            htmlContent += "<hr  style='border: 1px solid black;'/>";
            htmlContent += "<table style='width: 100%;'>";
            htmlContent += "<tbody>";
            htmlContent += $"<tr><td>APP NUMBER<br/>{application.AppNumber}</td><td style='text-align:right'>REGISTRATION NUMBER<br/><b>{application.applicant.studentnumber.studentnumber}</b></td></tr>";
            htmlContent += "</tbody>";
            htmlContent += "</table>";
            htmlContent += $"<div style='margin-top:10px;'>To: {application.applicant.Name} {application.applicant.Surname}</div>";
            htmlContent += $"<div>{application.applicant.Address}</div>";
            htmlContent += $"<div><u><b>RE:ADMISSION INTO THE {programme} ({mode}) {campus} </b></u></div>";
            htmlContent += "<p>The Zimbabwe Open University is pleased to offer you a place in the above mentioned programme. To accept this offer you are required to fulfill the following steps</p>";
            htmlContent += "<div style='text-align: left; margin-top:5px; font-weight: bolder;font-size: 18px;'><u>1. Document Verification</u></div>";
            htmlContent += "<p>This process  will determine the authenticity of your academic documents. In this regard  you are  required to  vist any of our regional campuses closest to you with your original identification and academic documents . Please note  applicants with verified documents will be allowed to proceed with their studies </p>";
            htmlContent += "<p>We would like to advise you that this offer is made without any prejudice to the rights,which the University may have to withdraw or cancel in the event of you or the University being unable to meet the conditions of the offerr</p>";
            htmlContent += "<div style='text-align: left; margin-top:5px;font-weight: bolder;font-size: 18px;'><u>2. Student Portal Activation</u></div>";
            htmlContent += "<p>Once your documents have been verified you are required to activate your student portal account  by visit https://portal.zou.ac.zw. On this portal you will be able to see minimum registration requirements</p>";
            htmlContent += "<p>Congratulations on being accepted for the programme</p>";
            htmlContent += "<p>Yours sincerely</p>";
            htmlContent += $"<p><img style=' width: 80px;' src='{signatureurl}'/></p>";
            htmlContent += "<p> Registrar Name</p>";
            htmlContent += "<p>DIRECTOR, ACADEMIC REGISTRY</p>";
            htmlContent += "</div>";
            return htmlContent;

        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false,

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            else
            {
                return principal;
            }
        }

        public string GetRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public TokenResponse GetToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                                             issuer: _configuration["JWT:ValidIssuer"],
                                             audience: _configuration["JWT:ValidAudience"],
                                             expires: DateTime.UtcNow.AddDays(7),
                                             claims: claims,
                                             signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                                             );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new TokenResponse { Token = tokenString, ValidTo = token.ValidTo };
        }

    }
}
