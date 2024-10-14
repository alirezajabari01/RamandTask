using Dapper;
using Domain.Users;
using Domain.Users.Contracts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF.Users
{
    public class UserRepository(IDbConnection db) : IUserRepository
    {
        public async Task<User?> FirstOrDefaultAsync(string storedProcedureName, object parameters, CancellationToken cancellationToken)
        {
            await using var connection = new SqlConnection(db.ConnectionString);
            await connection.OpenAsync(cancellationToken);
            return await connection.QueryFirstOrDefaultAsync<User>(
                storedProcedureName,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task InsertAsync(string storedProcedureName, object parameters, CancellationToken cancellationToken)
        {
            await using var connection = new SqlConnection(db.ConnectionString);
            await connection.OpenAsync(cancellationToken);
            await connection.ExecuteAsync(
                storedProcedureName, 
                parameters, 
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<User>> GetAllAsync(string storedProcedureName,CancellationToken cancellationToken)
        {
            await using var connection = new SqlConnection(db.ConnectionString);
            await connection.OpenAsync(cancellationToken);
            return await connection.QueryAsync<User>(
                storedProcedureName,
                commandType: CommandType.StoredProcedure
            );
             
        }
    }

}
