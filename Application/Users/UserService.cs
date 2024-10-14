using Application.Contract.Users;
using Application.Contract.Users.Responses;
using Application.UserFilters;
using Domain.Users.Contracts;

namespace Application.Users;

public class UserService(IUserRepository userRepository, IUserContext userContext) : IUserService
{
    public async Task<List<GetAllUsersResponse>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllAsync
        (
            "sp_GetAll",
            cancellationToken
        );
        return users.ToGetAllUsersResponseList();
    }
}