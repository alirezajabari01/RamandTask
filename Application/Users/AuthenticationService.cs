using Application.Contract.Users;
using Application.Contract.Users.Requests;
using Application.Contract.Users.Responses;
using Application.Security;
using Domain.Users.Contracts;

namespace Application.Users;

public class AuthenticationService(IUserRepository userRepository) : IAuthenticationService
{
    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var parameters = new
        {
            UserName = loginRequest.UserName,
            Password = loginRequest.Password.Salterhash()
        };
        var user = await userRepository.FirstOrDefaultAsync
                   (
                       "sp_GetByUserNameAndPassword",
                       parameters,
                       cancellationToken
                   )
                   ?? throw new NullReferenceException();
        return new LoginResponse(user.Generate());
    }

    public async Task RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        var parameters = new
        {
            UserName = request.UserName,
            Password = request.Password.Salterhash()
        };
        await userRepository.InsertAsync
        (
            "sp_Add",
            parameters,
            cancellationToken
        );
    }
}