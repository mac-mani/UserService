using Infra.SqlQueries.IQueries;

namespace Infra.SqlQueries.Postgres;

public class UserQuery : IUserQuery
{
    public string GetInsertUserQuery() =>
        """
        INSERT INTO Users (UserId, Email, Password, PersonName, Gender)
        VALUES (@UserId, @Email, @Password, @PersonName, @Gender)
        RETURNING *;
        """;

    public string GetUpdateUserQuery() =>
        """
        UPDATE Users SET 
                         Email = @Email, 
                         Password = @Password, 
                         PersonName = @PersonName, 
                         Gender = @Gender
        WHERE UserId = @UserId
        """;
    public string GetGetUserByEmailQuery() => "SELECT * FROM Users WHERE Email = @Email;";
}