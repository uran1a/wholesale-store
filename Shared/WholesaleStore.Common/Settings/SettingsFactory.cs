﻿using Microsoft.Extensions.Configuration;

namespace WholesaleStore.Common.Settings;

public static class SettingsFactory
{
    public static IConfiguration Create(IConfiguration configuration = null)
    {
        var conf = configuration ?? new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"), false)
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.development.json"), true)
            .AddEnvironmentVariables()
            .Build();

        return conf;
    }
}
