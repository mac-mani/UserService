using Domain.IRepositories;
using Infra.Persistence;
using Infra.Repositories;
using Infra.SqlQueries;
using Infra.SqlQueries.IQueries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infra;

public static class InfraServiceExtension
{
    public static void AddInfraService(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseType =configuration["DatabaseType"]; // "Postgres" or "SqlServer"
        
        if (databaseType?.ToLower() == "sqlserver")
        {
            services.AddScoped<IUserQuery, SqlQueries.SqlServer.UserQuery>();
            services.AddSingleton<IDbConnectionFactory, SqlServerConnectionFactory>();
        }
        else
        {
            services.AddScoped<IUserQuery, SqlQueries.Postgres.UserQuery>();
            services.AddSingleton<IDbConnectionFactory, PostgresConnectionFactory>();
        }
        services.AddScoped<IUserRepository, UserRepository>();
    }
}