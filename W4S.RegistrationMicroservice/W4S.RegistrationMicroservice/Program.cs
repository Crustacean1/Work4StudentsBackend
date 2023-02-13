using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.API.Services;
using W4S.RegistrationMicroservice.Data.DbContexts;
using W4S.ServiceBus.Extensions;
using W4SRegistrationMicroservice.CommonServices.Interfaces;
using W4SRegistrationMicroservice.CommonServices.Services;
using W4SRegistrationMicroservice.API.Validations.UserAuthentication;
using System.Text;
using W4SRegistrationMicroservice.API.Controllers;
using Serilog;
using W4S.RegistrationMicroservice.API.Host;
using W4S.RegistrationMicroservice.Data.Seeders;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.API.Services;
using W4S.RegistrationMicroservice.API.Controllers;
using System.Globalization;
using W4S.RegistrationMicroservice.API.Validations.Interfaces;
using W4S.RegistrationMicroservice.Validations;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(formatProvider: new CultureInfo("pl-PL"))
    .CreateLogger();

Log.Logger.Information("Staring application");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureUserbaseDbContext(builder.Services);
ConfigureValidators(builder.Services, builder.Configuration);
ConfigureServices(builder.Services);
ConfigureControllers(builder.Services);

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseAuthentication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureValidators(IServiceCollection services, IConfiguration configuration)
{
    ConfigureJwt(services, configuration);
}

void ConfigureJwt(IServiceCollection services, IConfiguration configuration)
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

void ConfigureServices(IServiceCollection services)
{
    services.TryAddScoped<IHasher, PasswordHasher>();
    services.TryAddScoped<UserbaseSeeder>();
    services.TryAddScoped<IRegistrationService, RegistrationService>();
    services.TryAddScoped<IDataValidator, DataValidator>();
    services.TryAddScoped<ISigningInService, SigningInService>();
    services.TryAddScoped<IProfilesService, ProfilesService>();
}

void ConfigureControllers(IServiceCollection services)
{
    services.TryAddScoped<RegistrationController>();
    services.TryAddScoped<SigningInController>();
    services.TryAddScoped<ProfilesController>();
    services.AddHostedService<MigrationHost>();
    services.AddServiceBus();
}

void ConfigureUserbaseDbContext(IServiceCollection services)
{
    services.AddDbContext<UserbaseDbContext>();
}
