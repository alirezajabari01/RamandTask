using Domain.Users;

namespace Application.Contract.Users.Responses;

public record GetAllUsersResponse(int Id, string UserName);

public static class GetAllUsersResponseMapper
{
    public static List<GetAllUsersResponse> ToGetAllUsersResponseList
        (this IEnumerable<User> users)
        => users.Select
        (
            user =>
                new GetAllUsersResponse
                (
                    user.Id,
                    user.UserName.Value
                )
        ).ToList();
}