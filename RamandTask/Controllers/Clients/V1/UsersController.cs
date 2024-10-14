using Application.Contract.Users;
using Application.Contract.Users.Responses;
using Microsoft.AspNetCore.Mvc;
using RamandTask.Attributes;
using RamandTask.Controllers.Base;

namespace RamandTask.Controllers.Clients.V1;

[ApiVersion("1")]
[CustomAuthorize]
public class UsersController(IUserService userService) : ApiBaseController
{
    [HttpGet]
    public async Task<IEnumerable<GetAllUsersResponse>> GetAll(CancellationToken cancellationToken)
        => await userService.GetAllUsersAsync(cancellationToken);
}