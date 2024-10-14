using Application.Contract.Users;
using Application.Contract.Users.Requests;
using Application.Contract.Users.Responses;
using Microsoft.AspNetCore.Mvc;
using RamandTask.Controllers.Base;

namespace RamandTask.Controllers.Clients.V1
{
    [ApiVersion("1")]
    public class AuthenticationController(IAuthenticationService authenticationService) : ApiBaseController
    {
        [HttpPost("[action]")]
        public async Task<LoginResponse> Login(LoginRequest loginRequest, CancellationToken cancellationToken)
            => await authenticationService.LoginAsync(loginRequest, cancellationToken);

        [HttpPost]
        public async Task Register(RegisterRequest request, CancellationToken cancellationToken)
            => await authenticationService.RegisterAsync(request, cancellationToken);
    }
}