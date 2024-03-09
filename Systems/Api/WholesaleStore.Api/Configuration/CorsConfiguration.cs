using WholesaleStore.Services.Settings;

namespace WholesaleStore.Api.Configuration;

public static class CorsConfiguration
{
    public static IServiceCollection AddAppCors(this IServiceCollection services)
    {
        services.AddCors();

        return services;
    }

    public static void UseAppCors(this WebApplication app)
    {
        var mainSettings = app.Services.GetService<MainSettings>();

        var origins = mainSettings.AllowedOrigins.Split(',', ';').Select(x => x.Trim())
            .Where(x => !string.IsNullOrEmpty(x)).ToArray();

        app.UseCors(pol =>
        {
            pol.WithHeaders().AllowAnyHeader();
            pol.WithOrigins("http://localhost:5173");
            pol.WithMethods().AllowAnyMethod();
/*
            pol.AllowAnyHeader();
            pol.AllowAnyMethod();
            pol.AllowCredentials();
            if (origins.Length > 0)
                pol.WithOrigins(origins);
            else
                pol.SetIsOriginAllowed(origin => true);

            pol.WithExposedHeaders("Content-Disposition");*/
        });
    }
}