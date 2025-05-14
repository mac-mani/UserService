using Infra.SqlQueries.IQueries;

namespace Infra.SqlQueries.SqlServer;

public class UserQuery : IUserQuery
{
    public string GetInsertUserQuery() =>
        """
        INSERT INTO Users (UserId, Email, Password, PersonName, Gender)
        VALUES (@UserId, @Email, @Password, @PersonName, @Gender);
        """;

    public string GetGetUserByEmailQuery() => "SELECT * FROM Users WHERE Email = @Email;";
    public string GetUpdateUserQuery()
    {
        throw new NotImplementedException();
    }
}

// SELECT * FROM Users WHERE UserId = SCOPE_IDENTITY();