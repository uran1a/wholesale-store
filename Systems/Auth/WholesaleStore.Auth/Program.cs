using Microsoft.EntityFrameworkCore;
using WholesaleStore.Auth.Context;
using WholesaleStore.Common.Settings;
using WholesaleStore.Services.Settings.Settings;
using WholesaleStore.Auth.Configuration;
using WholesaleStore.Auth.Services;
using WholesaleStore.Services.Settings;

var jwtSettings = Settings.Load<JwtSettings>("Jwt");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetSection("Database:ConnectionString").Value);
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddJwtSettings();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddAppAuth(jwtSettings);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAppAuth();

app.MapControllers();

app.Run();

