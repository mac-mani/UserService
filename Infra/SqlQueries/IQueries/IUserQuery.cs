namespace Infra.SqlQueries.IQueries;

public interface IUserQuery
{
    string GetInsertUserQuery();
    string GetGetUserByEmailQuery();
    string GetUpdateUserQuery();
}