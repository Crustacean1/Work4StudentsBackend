using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using W4SRegistrationMicroservice.API.Interfaces;
using W4SRegistrationMicroservice.API.Services;
using W4SRegistrationMicroservice.Data.DbContexts;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureLogger(builder.Host);

ConfigureUserbaseDbContext(builder.Services, builder.Configuration.GetConnectionString("W4SRegistrationUserbase"));

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureLogger(ConfigureHostBuilder host)
{
    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));
}

void ConfigureServices(IServiceCollection services)
{
    services.TryAddScoped<IRegistrationService, RegistrationService>();
}

void ConfigureUserbaseDbContext(IServiceCollection services, string connectionString)
{
    services.AddDbContext<W4SUserbaseDbContext>(options =>
        options.UseSqlServer(connectionString));
}