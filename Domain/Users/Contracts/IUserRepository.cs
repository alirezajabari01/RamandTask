using System.Linq.Expressions;
using Domain.Abstractions;

namespace Domain.Users.Contracts;

public interface IUserRepository : IRepository, IScopeLifeTime
{
    public Task<User?> FirstOrDefaultAsync(string storedProcedureName, object parameters,
        CancellationToken cancellationToken);

    Task InsertAsync(string storedProcedureName, object parameters,
        CancellationToken cancellationToken);

    Task<IEnumerable<User>> GetAllAsync(string storedProcedureName, CancellationToken cancellationToken);
}