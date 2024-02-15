using WholesaleStore.Api;
using WholesaleStore.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAppAutoMappers()
    .AddAppValidator()
    .RegisterServices()
    .AddAppCors()
    .AddAppControllerAndViews();

var app = builder.Build();

app.UseAppCors();
app.UseAppControllerAndViews();

app.Run();
