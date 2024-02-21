using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Settings;

namespace WholesaleStore.Context.Factories;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    public MainDbContext CreateDbContext(string[] args)
    {
        var provider = (args?[0] ?? $"{DbType.PostgreSql}").ToLower();

        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.context.json"), false)
            .Build();

        var connectionString = configuration.GetConnectionString(provider);

        DbType dbType;
        if (provider.Equals($"{DbType.PostgreSql}".ToLower()))
            dbType = DbType.PostgreSql;
        else
            throw new Exception($"Unsupported provider: {provider}");

        var options = DbContextOptionsFactory.Create(connectionString, dbType, false);
        var factory = new DbContextFactory(options);
        var context = factory.Create();

        return context;
    }
}
