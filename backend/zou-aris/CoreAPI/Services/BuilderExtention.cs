using CoreAPI.Data;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using CoreAPI.Services.Auth;
using CoreAPI.Services.Dashboard;
using CoreAPI.Services.PaynowService;
using CoreAPI.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CoreAPI.Services
{
    public static class BuilderExtention
    {
        public static void DbContextConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionstring = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CoreDbContext>(options =>
            {
                options.UseNpgsql(connectionstring);
            });
        }

        public static void IdentinntyConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                     .AddEntityFrameworkStores<CoreDbContext>()
                     .AddDefaultTokenProviders();
        }
        public static void AuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });
        }

        public static void ServiceConfiguration(this IServiceCollection services)
        {

            services.AddTransient<IUnitOfWork, UnitOfWork>(); 
            services.AddTransient<ResponseDto, ResponseDto>();
            services.AddTransient<HelperFunctions, HelperFunctions>();
            services.AddTransient<IPaynowHelper,PaynowHelper>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<IAuthService,AuthService>();
        }
    }
}
