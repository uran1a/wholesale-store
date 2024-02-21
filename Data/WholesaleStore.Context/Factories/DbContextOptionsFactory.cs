using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Context;
using DbType = WholesaleStore.Context.Settings.DbType;

namespace WholesaleStore.Context.Factories;

public static class DbContextOptionsFactory
{
    private const string migrationProjectPrefix = "WholesaleStore.Context.Migrations.";

    public static DbContextOptions<MainDbContext> Create(string connectionString, DbType dbType, bool detailedLogging = false)
    {
        var builder = new DbContextOptionsBuilder<MainDbContext>();

        Configure(connectionString, dbType, detailedLogging).Invoke(builder);

        return builder.Options;
    }

    public static Action<DbContextOptionsBuilder> Configure(string connectionString, DbType dbType, bool detailedLogging = false)
    {
        return (builder) =>
        {
            switch (dbType)
            {
                case DbType.PostgreSql:
                    builder.UseNpgsql(connectionString,
                            opts => opts
                                .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                                .MigrationsHistoryTable("_migrations")
                                .MigrationsAssembly($"{migrationProjectPrefix}{DbType.PostgreSql}")
                        );
                    break;
            }

            if (detailedLogging)
                builder.EnableSensitiveDataLogging();

            builder.UseLazyLoadingProxies(true);
        };
    }
}
