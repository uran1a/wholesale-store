using WholesaleStore.Api;
using WholesaleStore.Api.Configuration;
using WholesaleStore.Common.Settings;
using WholesaleStore.Services.Logger.Logger;
using WholesaleStore.Services.Settings;
using WholesaleStore.Context;
using WholesaleStore.Context.Setup;
using WholesaleStore.Context.Seeder.Seeds;
using WholesaleStore.Services.Settings.Settings;


var mainSettings = Settings.Load<MainSettings>("Main");
var loggerSettings = Settings.Load<LoggerSettings>("Logger");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");
var identitySettings = Settings.Load<IdentitySettings>("Identity");

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger(mainSettings, loggerSettings);


var services = builder.Services;

services.AddHttpContextAccessor();

services.AddAppDbContext(builder.Configuration);

services.AddAppCors();

services.AddAppHealthChecks();

services.AddAppVersioning();

services.AddAppSwagger(mainSettings, swaggerSettings, identitySettings);

services.AddAppAutoMappers();

services.AddAppValidator();

services.AddAppAuth(identitySettings);

services.AddAppControllerAndViews();

services.RegisterServices(builder.Configuration);


var app = builder.Build();

var logger = app.Services.GetRequiredService<IAppLogger>();

app.UseAppCors();

app.UseAppHealthChecks();

app.UseAppSwagger();

app.UseAppAuth();

app.UseAppControllerAndViews();

DbInitializer.Execute(app.Services);

DbSeeder.Execute(app.Services);

logger.Information("The WholesaleStore.API has started");

app.Run();

logger.Information("The WholesaleStore.API has stopped");
