using Dapper;
using Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF.Users
{
    public class PasswordTypeHandler : SqlMapper.TypeHandler<Password>
    {
        public override void SetValue(IDbDataParameter parameter, Password value)
        {
            parameter.Value = value.Value; // Convert UserName to its string value for DB operations
        }

        public override Password Parse(object value)
        {
            return new Password(value.ToString()); // Convert string from DB to UserName
        }
    }
}
