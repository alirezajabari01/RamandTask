using Application.Contract.Users.Requests;
using Application.Contract.Users.Responses;
using Domain.Abstractions;

namespace Application.Contract.Users;

public interface IAuthenticationService : IScopeLifeTime
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest,CancellationToken cancellationToken);
    Task RegisterAsync(RegisterRequest request, CancellationToken cancellationToken);
}