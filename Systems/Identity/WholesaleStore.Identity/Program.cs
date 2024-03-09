using WholesaleStore.Common.Settings;
using WholesaleStore.Identity.Configuration;
using WholesaleStore.Identity;
using WholesaleStore.Services.Settings;
using WholesaleStore.Context;

var loggerSettings = Settings.Load<LoggerSettings>("Logger");

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger(loggerSettings);

// Configure services
var services = builder.Services;

//services.AddAppCors();

services.AddHttpContextAccessor();

services.AddAppDbContext(builder.Configuration);

services.AddAppHealthChecks();

services.RegisterAppServices();

services.AddIS();


// Configure the HTTP request pipeline.

var app = builder.Build();

//app.UseAppCors();

app.UseAppHealthChecks();

app.UseIS();


// Run app

app.Run();