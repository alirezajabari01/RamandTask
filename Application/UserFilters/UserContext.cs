using System.Security.Authentication;
using System.Security.Claims;
using Application.Security;
using Microsoft.AspNetCore.Http;

namespace Application.UserFilters;

public class UserContext : IUserContext
{
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        // var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
        // if (!string.IsNullOrEmpty(token))
        // {
        //     var claimPrinciple = TokenGenerator.ValidateToken(token);
        //     if (claimPrinciple != null)
        //     {
        //         var userId = claimPrinciple.Claims.FirstOrDefault(x => x.Type == "userid")?.Value;
        //         var userName = claimPrinciple.Claims.FirstOrDefault(x => x.Type == "userName")?.Value;
        //         UserId = int.Parse(userId);
        //         UserName = userName;
        //     }
        // }
        // else
        // {
        //     throw new UnauthorizedAccessException("Invalid token");
        // }
    }
    public int UserId { get; set; }
    public string UserName { get; set; }
}