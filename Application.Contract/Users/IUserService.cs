using Application.Contract.Users.Responses;
using Domain.Abstractions;

namespace Application.Contract.Users;

public interface IUserService : IScopeLifeTime
{
    Task<List<GetAllUsersResponse>> GetAllUsersAsync(CancellationToken cancellationToken);
}