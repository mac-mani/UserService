using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infra.Persistence;

public class SqlServerConnectionFactory(IConfiguration configuration) : IDbConnectionFactory
{
    private readonly string? _connectionString = configuration.GetConnectionString("PostgresConnection");
    public IDbConnection CreateConnection()
    {
       // return new SqlConnection(_connectionString);
        return new NpgsqlConnection(_connectionString);
    }
}