using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Seeder.Seeds.Demo;
using WholesaleStore.Context.Settings;

namespace WholesaleStore.Context.Seeder.Seeds;

public static class DbSeeder
{
    private static IServiceScope ServiceScope(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();
    }
    private static MainDbContext DbContext(IServiceProvider serviceProvider)
    {
        return ServiceScope(serviceProvider)
            .ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>().CreateDbContext();
    }
    public static void Execute(IServiceProvider serviceProvider)
    {
        Task.Run(async () =>
        {
            await AddDemoData(serviceProvider);
        })
        .GetAwaiter()
        .GetResult();
    }
    private static async Task AddDemoData(IServiceProvider serviceProvider)
    {
        using var scope = ServiceScope(serviceProvider);
        if (scope == null)
            return;

        var settings = scope.ServiceProvider.GetService<DbSettings>();
        if (!(settings.Init?.AddDemoData ?? false))
            return;

        await using var context = DbContext(serviceProvider);

        if (await context.Warehouses.AnyAsync())
            return;

        await context.Warehouses.AddRangeAsync(new DemoHelper().GetWarehouses);

        if (await context.Products.AnyAsync())
            return;

        await context.Products.AddRangeAsync(new DemoHelper().GetProducts);

        await context.SaveChangesAsync();
    }
}
