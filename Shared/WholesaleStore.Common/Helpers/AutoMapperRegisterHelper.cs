using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WholesaleStore.Common.Helpers;

public static class AutoMapperRegisterHelper
{
    public static void Register(IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(s => s.FullName != null && s.FullName.ToLower().StartsWith("wholesalestore."));

        services.AddAutoMapper(assemblies);
    }
}
