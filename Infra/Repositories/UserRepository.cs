using Dapper;
using Domain.Entities;
using Domain.IRepositories;
using Infra.Persistence;
using Infra.SqlQueries.IQueries;

namespace Infra.Repositories;

internal class UserRepository(IDbConnectionFactory dbConnectionFactory, 
    IUserQuery userQuery) : IUserRepository
{
    public async Task<ApplicationUser?> InsertUserAsync(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        var query = userQuery.GetInsertUserQuery();
        using var connection = dbConnectionFactory.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, user);
        return result;
        //return await connection.QuerySingleAsync<ApplicationUser>(query, user);
        //return await connection.ExecuteAsync(sql, user);
    }

    public async Task<ApplicationUser?> UpdateUserAsync(ApplicationUser user, string userId)
    {
        var query = userQuery.GetUpdateUserQuery();
        using var connection = dbConnectionFactory.CreateConnection();
        user.UserId = Guid.Parse(userId);
        var result = await connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, user);
        return result;
    }

    public async Task<ApplicationUser?> GetUserByEmailAsync(string email, string password)
    {
        using var connection = dbConnectionFactory.CreateConnection();
        var query = userQuery.GetGetUserByEmailQuery();
        var result = await connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { Email = email });
        return result;
    }
}