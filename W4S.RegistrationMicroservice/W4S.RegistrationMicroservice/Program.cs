using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.API.Services;
using W4SRegistrationMicroservice.Data.DbContexts;
using W4S.ServiceBus.Extensions;
using W4SRegistrationMicroservice.Data.Seeders;
using W4SRegistrationMicroservice.Data.Seeders.Interface;
using W4SRegistrationMicroservice.CommonServices.Interfaces;
using W4SRegistrationMicroservice.CommonServices.Services;
using W4SRegistrationMicroservice.API.Validations.UserAuthentication;
using System.Text;
using W4SRegistrationMicroservice.API.Controllers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureLogger(builder.Host);

ConfigureUserbaseDbContext(builder.Services, builder.Configuration.GetConnectionString("W4SRegistrationUserbase"));
ConfigureValidators(builder.Services, builder.Configuration);

ConfigureServices(builder.Services);

var app = builder.Build();

app.UseAuthentication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

SeedUsersDatabase();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureLogger(ConfigureHostBuilder host)
{
    builder.Logging.ClearProviders();
    builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));
}

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
    services.TryAddScoped<ISeeder, W4SUserbaseSeeder>();
    services.TryAddScoped<IRegistrationService, RegistrationService>();
    services.TryAddScoped<ISigningInService, SigningInService>();
    services.TryAddScoped<RegistrationController>();
    services.TryAddScoped<RegistrationController>();
    services.AddServiceBus();
}

void ConfigureUserbaseDbContext(IServiceCollection services, string connectionString)
{
    services.AddDbContext<W4SUserbaseDbContext>(options =>
        options.UseSqlServer(connectionString));
}

void SeedUsersDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<ISeeder>();
        dbInitializer.Seed();
    }
}
