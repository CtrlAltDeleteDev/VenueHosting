using Component.Persistence.SqlServer.AtomicScope;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Component.Persistence.SqlServer;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainDbContext<TDbContext>(this IServiceCollection serviceCollection,
        IConfiguration configuration) where TDbContext : DbContext
    {
        var connectionString = configuration.GetConnectionString("SqlServerConnectionString");

        serviceCollection.TryAddSingleton<IAtomicScopeFactory, AtomicScopeFactory<TDbContext>>();

        serviceCollection.AddDbContext<TDbContext>(x => x.UseSqlServer(connectionString,
            builder => builder.MigrationsHistoryTable(HistoryRepository.DefaultTableName)));

        //TODO: Add extension convention for enums to cast them into separate table.
        //TODO: Add interceptors for auditing.
        //TODO: Add extend DBContextOptions.

        return serviceCollection;
    }
}