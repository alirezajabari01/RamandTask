using Dapper;
using Domain.Users.ValueObjects;
using System.Data;

public class UserNameTypeHandler : SqlMapper.TypeHandler<UserName>
{
    public override void SetValue(IDbDataParameter parameter, UserName value)
    {
        parameter.Value = value.Value; // Convert UserName to its string value for DB operations
    }

    public override UserName Parse(object value)
    {
        return new UserName(value.ToString()); // Convert string from DB to UserName
    }
}
