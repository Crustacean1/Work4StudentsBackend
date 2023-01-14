using W4S.PostingService.Domain.Abstractions;
using W4S.PostingService.Domain.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using W4S.Gateway.Console.CommonSettings;
using W4S.ServiceBus.Extensions;

namespace W4S.Gateway.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services);
            ConfigureJwt(builder.Services, builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddServiceBus();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }
            app.UseSwagger();
            app.UseSwaggerUI();

            //app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddServiceBus();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void ConfigureJwt(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationSettings>(options => configuration.GetSection(nameof(AuthenticationSettings)).Bind(options));

            var authentiactionSettings = new AuthenticationSettings();
            configuration.GetSection(nameof(AuthenticationSettings)).Bind(authentiactionSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authentiactionSettings.JwtIssuer,
                    ValidAudience = authentiactionSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authentiactionSettings.JwtKey))
                };
            });
        }
    }
}
