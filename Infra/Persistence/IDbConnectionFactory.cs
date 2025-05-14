using System.Data;

namespace Infra.Persistence;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}